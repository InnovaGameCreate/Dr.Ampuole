using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private GameObject bullet;
        private Transform scopeCameraTransform;

        private void Start()
        {
            scopeCameraTransform = GetComponentInChildren<Camera>().transform;

            // インターバル 3 秒で弾を撃つ
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
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