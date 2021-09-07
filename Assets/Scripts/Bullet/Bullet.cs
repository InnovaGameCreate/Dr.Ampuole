using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        private const float DestoryTime = 5.0f;
        public BulletType bulletType { get; set; }

        private void Start()
        {
            Destroy(gameObject, DestoryTime);
        }
    }
}