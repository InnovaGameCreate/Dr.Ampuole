using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Patient;

namespace UI.Main.Presenter
{
    public class MainPresenter : MonoBehaviour
    {
        [SerializeField]
        private PatientSpawn patientSpawn;

        [SerializeField]
        private PatientCountManager countManager;

        private void Start()
        {
            patientSpawn.CurrentWave
                .SkipLatestValueOnSubscribe()
                .Subscribe(waveCount =>
                {
                    // wave をすべて攻略した時
                    if (waveCount == 4)
                    {

                    }
                    // wave が始まった時
                    else
                    {
                    }
                }).AddTo(this);

            // すべての患者を倒した時
            countManager.CurrentPatientCount
                .SkipLatestValueOnSubscribe()
                .Where(count => count <= 0)
                .Subscribe(count =>
                {
                }).AddTo(this);
        }
    }
}