using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Systems.GameState;
using System.Linq;

namespace Systems.Audio
{
    public class BgmManager : MonoBehaviour
    {
        public static BgmManager Instance { get; private set; }

        private AudioSource audioSource;

        [SerializeField]
        private List<AudioClip> bgmLists;

        private void Awake()
        {
            if (Instance == null)
            {
                audioSource = GetComponent<AudioSource>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            GameStateController.Instance.CurrentGameState
                .Subscribe(state =>
                {
                    switch (state)
                    {
                        case GameState.GameState.Title:
                            ShotBGM(state);
                            return;
                        case GameState.GameState.Main:
                            ShotBGM(state);
                            return;
                        case GameState.GameState.Result:
                            ShotBGM(state);
                            return;
                        default:
                            return;
                    }
                }).AddTo(this);
        }

        private void ShotBGM(GameState.GameState state)
        {
            var bgm = bgmLists.First(bgm => bgm.name.Equals(state.ToString()));

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = bgm;
            audioSource.Play();
        }
    }
}