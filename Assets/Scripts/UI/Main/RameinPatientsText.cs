using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Patient;

namespace UI.Main
{
    public class RameinPatientsText : MonoBehaviour
    {
        private Text text;
        [SerializeField]
        private PatientCountManager manager;

        private void Start()
        {
            text = GetComponent<Text>();

            manager.CurrentPatientCount
                .Subscribe(count =>
                {
                    text.text = "残り: " + count.ToString();
                }).AddTo(this);
        }
    }
}