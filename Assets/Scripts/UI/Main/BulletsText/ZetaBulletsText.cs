using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI.Main
{
    public class ZetaBulletsText : MonoBehaviour
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
            text.text = bulletCount.ZetaBullets.ToString();
        }
    }
}
