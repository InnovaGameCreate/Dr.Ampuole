using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
