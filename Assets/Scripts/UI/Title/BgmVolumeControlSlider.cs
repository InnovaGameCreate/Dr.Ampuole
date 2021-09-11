using UnityEngine;
using UnityEngine.UI;

public class BgmVolumeControlSlider : MonoBehaviour
{
    private Slider slider;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GameObject.Find("BGMAudioSource").GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        slider.value = audioSource.volume;
    }

    void Update()
    {
        audioSource.volume = slider.value;
    }
}
