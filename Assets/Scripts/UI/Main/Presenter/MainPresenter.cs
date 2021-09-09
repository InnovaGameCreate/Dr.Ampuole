using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Patient;
using UnityEngine.UI;

namespace UI.Main.Presenter
{
    public class MainPresenter : MonoBehaviour
    {
        [SerializeField]
        private PatientSpawn patientSpawn;

        [SerializeField]
        private PatientCountManager countManager;

        public Text text;

        private void Start()
        {
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
                    Debug.Log("一応文章入れておこうかなと思うけれど、これって結局意味ないのではと考えた。でもそれは今こんなことを考えながらタイプしている自分が悪いのだ。");
                }).AddTo(this);
        }
    }
}