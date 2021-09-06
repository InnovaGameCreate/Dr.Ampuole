using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Slider���g�p���邽�߂ɕK�v

[RequireComponent(typeof(Slider))]
public class Volume : MonoBehaviour
{
    Slider m_Slider;//���ʒ����p�X���C�_�[

    [SerializeField]
    bool m_isInput;//�L�[���͂Œ����o�[�𓮂�����悤�ɂ��邩
    [SerializeField]
    float m_ScroolSpeed = 1;//�L�[���͂Œ����o�[�𓮂����X�s�[�h
    void Awake()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.value = AudioListener.volume;
    }

    private void OnEnable()
    {
        m_Slider.value = AudioListener.volume;
        //�X���C�_�[�̒l���ύX���ꂽ�特�ʂ��ύX����
        m_Slider.onValueChanged.AddListener((sliderValue) => AudioListener.volume = sliderValue);
    }

    private void OnDisable()
    {
        m_Slider.onValueChanged.RemoveAllListeners();
    }
    //�L�[���͂ɂ�鑀��@����Ȃ��Ȃ�폜���Ă�OK


    // Update is called once per frame
    void Update()
    {
        float v = m_Slider.value;
        if (m_isInput)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                v -= m_ScroolSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                v += m_ScroolSpeed * Time.deltaTime;
            }
        }
        v = Mathf.Clamp(v, 0, 1);
        m_Slider.value = v;
    }
}
