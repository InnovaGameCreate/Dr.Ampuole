using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    public class BulletView : MonoBehaviour
    {
        public Image Image { get; private set; }

        private void Awake()
        {
            Image = GetComponent<Image>();
        }
    }
}
