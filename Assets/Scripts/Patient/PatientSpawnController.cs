using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UniRx;
using Systems.GameState;

namespace Patient
{
    public class PatientSpawnController : MonoBehaviour
    {
        private ReactiveProperty<int> currentWave = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> CurrentWave => currentWave;
        private List<Transform> patientSpawnPoints = new List<Transform>();

        [SerializeField]
        private GameObject[] patientsPrefabs;

        private void Start()
        {
            foreach (Transform point in transform)
            {
                patientSpawnPoints.Add(point);
            }

            CurrentWave
                .SkipLatestValueOnSubscribe()
                .Subscribe(_ =>
                {
                    var g = Instantiate(patientsPrefabs[0], patientSpawnPoints[0].position, patientSpawnPoints[0].rotation);
                }).AddTo(this);

            GameStateController.Instance.CurrentGameState
                .Where(state => state == GameState.Main)
                .Subscribe(_ =>
                {
                    InitialWave();
                }).AddTo(this);
        }

        public void InitialWave()
        {
            currentWave.Value = 1;
        }

        public void NextWave()
        {
            currentWave.Value++;
        }
    }
}