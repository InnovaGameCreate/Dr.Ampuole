using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Bullets;
using Player.Scope;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private GameObject bullet;
        private Transform scopeCameraTransform;
        private PlayerChoiceBullet playerChoiceBullet;
        private ScopeControl scopeControl;

        private void Start()
        {
            scopeCameraTransform = GetComponentInChildren<Camera>().transform;
            scopeControl = GetComponent<ScopeControl>();
            playerChoiceBullet = GetComponent<PlayerChoiceBullet>();

            // インターバル 3 秒で弾を撃つ
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0) && scopeControl.IsShow)
                .ThrottleFirst(TimeSpan.FromSeconds(3.0f))
                .Subscribe(_ =>
                {
                    var mousePos = Input.mousePosition;
                    mousePos.z = 1.0f;
                    var mousePos3d = Camera.main.ScreenToWorldPoint(mousePos);

                    var force = (mousePos3d - transform.position) * 1000.0f;
                    ShootBullet(force);
                }).AddTo(this);
        }

        // 弾の生成
        private GameObject BuildBullet()
        {
            var b = Instantiate(bullet) as GameObject;
            b.GetComponent<Bullet>().bulletType = playerChoiceBullet.CurrentBulletType.Value;
            b.transform.position = transform.position;
            b.transform.rotation = scopeCameraTransform.rotation;
            return b;
        }

        private void ShootBullet(Vector3 force)
        {
            var b = BuildBullet();
            b.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}