using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UniRx;
using Systems.GameState;

namespace Patient
{
    public class PatientSpawn : MonoBehaviour
    {
        private ReactiveProperty<int> currentWave = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> CurrentWave => currentWave;
        private List<Transform> patientSpawnPoints = new List<Transform>();
        private Coroutine routine = null;
        private Coroutine nextWaveRoutine = null;
        private Coroutine resultRoutine = null;

        [SerializeField]
        private GameObject[] patientsPrefabs;
        private PatientCountManager patientCountManager;

        private float WaitTime = 3.0f;

        private void Start()
        {
            patientCountManager = GetComponent<PatientCountManager>();

            foreach (Transform point in transform)
            {
                patientSpawnPoints.Add(point);
            }

            CurrentWave
                .SkipLatestValueOnSubscribe()
                .Where(waveCount => waveCount <= 4)
                .Subscribe(waveCount =>
                {
                    if (waveCount == 4)
                    {
                        if (resultRoutine == null)
                        {
                            resultRoutine = StartCoroutine(ResultRoutine());
                        }
                    }
                    else
                    {
                        Wave(waveCount);
                    }
                }).AddTo(this);

            GameStateController.Instance.CurrentGameState
                .Where(state => state == GameState.Main)
                .Subscribe(_ =>
                {
                    InitialWave();
                }).AddTo(this);

            patientCountManager.CurrentPatientCount
                .SkipLatestValueOnSubscribe()
                .Where(count => count == 0)
                .Subscribe(_ =>
                {
                    if (nextWaveRoutine == null)
                    {
                        nextWaveRoutine = StartCoroutine(NextWave());
                    }
                }).AddTo(this);
        }

        private void Wave(int waveCount)
        {
            if (routine == null)
            {
                routine = StartCoroutine(WaveRoutine(waveCount));
                patientCountManager.SetPatientCount(waveCount * patientSpawnPoints.Count);
            }
        }

        private IEnumerator ResultRoutine()
        {
            yield return new WaitForSeconds(3.0f);
            GameStateController.Instance.ChangeToResult();
            resultRoutine = null;
        }

        private IEnumerator WaveRoutine(int waveCount)
        {
            for (var i = 1; i <= waveCount; i++)
            {
                foreach (var point in patientSpawnPoints)
                {
                    var cnt = UnityEngine.Random.Range(0, patientsPrefabs.Length);
                    Instantiate(patientsPrefabs[cnt], point.position, point.rotation);
                }
                yield return new WaitForSeconds(5.0f);
            }
            routine = null;
        }

        public void InitialWave()
        {
            currentWave.Value = 1;
        }

        private IEnumerator NextWave()
        {
            yield return new WaitForSeconds(WaitTime);
            currentWave.Value++;
            nextWaveRoutine = null;
        }
    }
}