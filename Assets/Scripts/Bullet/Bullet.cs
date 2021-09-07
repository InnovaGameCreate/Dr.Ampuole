using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        private const float DestoryTime = 5.0f;
        private void Start()
        {
            Destroy(gameObject, DestoryTime);
        }
    }
}