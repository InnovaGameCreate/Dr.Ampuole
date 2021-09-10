using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Patient;

namespace UI.Main
{
    public class OperatorText : MonoBehaviour
    {
        [SerializeField]
        private PatientSpawn patientSpawn;

        [SerializeField]
        private PatientCountManager countManager;
        private Text text;

        private void Start()
        {
            text = GetComponent<Text>();

            patientSpawn.CurrentWave
                .SkipLatestValueOnSubscribe()
                .Subscribe(waveCount =>
                {
                    // wave をすべて攻略した時
                    if (waveCount == 4)
                    {
                        text.text = "ウェーブがall終わった（仮）";
                        Debug.Log("特になし");
                    }
                    // wave が始まった時
                    else
                    {
                        text.text = "ウェーブが始まった（仮）";
                    }
                }).AddTo(this);

            // すべての患者を倒した時
            countManager.CurrentPatientCount
                .SkipLatestValueOnSubscribe()
                .Where(count => count <= 0)
                .Subscribe(count =>
                {
                    text.text = "患者の殲滅に成功した！（仮）";
                }).AddTo(this);
        }
    }
}