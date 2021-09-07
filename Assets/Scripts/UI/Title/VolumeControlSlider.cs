using UnityEngine;
using UnityEngine.UI;

public class VolumeControlSlider : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private AudioSource audioSource;
   

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0.5f;
    }

    void Update()
    {
        audioSource.volume = slider.value;
    }
}
