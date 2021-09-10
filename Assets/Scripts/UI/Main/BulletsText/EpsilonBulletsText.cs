using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI.Main
{
    public class EpsilonBulletsText : MonoBehaviour
    {
        [SerializeField]
        private PlayerBulletCount bulletCount;

        private Text text;

        private void Start()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            text.text = bulletCount.EpsilonBullets.ToString();
        }
    }
}
