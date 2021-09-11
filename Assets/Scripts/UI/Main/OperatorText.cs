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

        [SerializeField]
        private Animator anim;
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
                        anim.SetTrigger("isTalk");
                        text.text = "これで完全にこの街から感染者は居なくなりました！\nゆっくり身体を休めてください。ドクター。";
                    }
                    // wave 1 が始まった時
                    else if (waveCount == 1)
                    {
                        anim.SetTrigger("isTalk");
                        text.text = "ドクター、この街で新たな感染者を発見しました。\n早急に対応してください。";
                    }
                    // wave 2 が始まった時
                    else if (waveCount == 2)
                    {
                        anim.SetTrigger("isTalk");
                        text.text = "どうしよう…感染者がこんなに現れるなんて想定外です。\n厳しい状況ですがあなたを信じています。";
                    }
                    // wave 3 が始まった時
                    else if (waveCount == 3)
                    {
                        anim.SetTrigger("isTalk");
                        text.text = "これは…。おそらく次が本当に最後の感染者たちです。\n私も全力でバックアップします。";
                    }
                }).AddTo(this);

            // すべての患者を倒した時
            countManager.CurrentPatientCount
                .SkipLatestValueOnSubscribe()
                .Where(count => count <= 0)
                .Subscribe(count =>
                {
                    anim.SetTrigger("isTalk");
                    text.text = "今のが最後の感染者です！やりましたね！";
                }).AddTo(this);
        }
    }
}