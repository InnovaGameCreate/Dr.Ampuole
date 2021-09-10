using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Bullets;
using Player.Scope;
using Systems.Audio;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private GameObject bullet;
        private Transform scopeCameraTransform;
        private PlayerChoiceBullet playerChoiceBullet;
        private PlayerBulletCount bulletCount;
        private ScopeControl scopeControl;
        private const float Force = 3000.0f;

        private void Start()
        {
            scopeCameraTransform = GetComponentInChildren<Camera>().transform;
            scopeControl = GetComponent<ScopeControl>();
            playerChoiceBullet = GetComponent<PlayerChoiceBullet>();
            bulletCount = GetComponent<PlayerBulletCount>();

            // インターバル 1.5 秒で弾を撃つ
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0) && scopeControl.IsShow)
                .Where(_ => CanShoot())
                .ThrottleFirst(TimeSpan.FromSeconds(1.5f))
                .Subscribe(_ =>
                {
                    var mousePos = Input.mousePosition;
                    mousePos.z = 1.0f;
                    var mousePos3d = Camera.main.ScreenToWorldPoint(mousePos);

                    var force = (mousePos3d - transform.position) * Force;
                    ShootBullet(force);
                }).AddTo(this);
        }

        private bool CanShoot()
        {
            switch (playerChoiceBullet.CurrentBulletType.Value)
            {
                case BulletType.Delta:
                    if (bulletCount.DeltaBullets <= 0)
                    {
                        // ここに弾切れの音
                        return false;
                    }
                    return true;
                case BulletType.Epsilon:
                    if (bulletCount.EpsilonBullets <= 0)
                    {
                        // ここに弾切れの音
                        return false;
                    }
                    return true;
                case BulletType.Zeta:
                    if (bulletCount.ZetaBullets <= 0)
                    {
                        // ここに弾切れの音
                        return false;
                    }
                    return true;
                default:
                    return true;
            }
        }

        // 弾の生成
        private GameObject BuildBullet()
        {
            var b = Instantiate(bullet) as GameObject;
            var bt = playerChoiceBullet.CurrentBulletType.Value;
            b.GetComponent<Bullet>().bulletType = bt;

            if (bt == BulletType.Delta)
            {
                bulletCount.DeltaBullets--;
            }
            else if (bt == BulletType.Epsilon)
            {
                bulletCount.EpsilonBullets--;
            }
            else if (bt == BulletType.Zeta)
            {
                bulletCount.ZetaBullets--;
            }

            b.transform.position = transform.position;
            b.transform.rotation = scopeCameraTransform.rotation;
            return b;
        }

        private void ShootBullet(Vector3 force)
        {
            var b = BuildBullet();
            b.GetComponent<Rigidbody>().AddForce(force);
            SeManager.Instance.ShotSe(SeType.ShootAndReroad);
        }
    }
}