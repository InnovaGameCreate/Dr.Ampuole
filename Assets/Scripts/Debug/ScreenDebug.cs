using UnityEngine;
using UnityEngine.UI;

namespace ScreenDebug
{
    public class ScreenDebug : MonoBehaviour
    {
        [SerializeField]
        private Text widthText;

        [SerializeField]
        private Text heightText;

        private void FixedUpdate()
        {
            widthText.text = "Width: " + Screen.width;
            heightText.text = "Height: " + Screen.height;
        }
    }
}