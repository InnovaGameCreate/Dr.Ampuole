using UnityEngine;
using UniRx;

namespace Systems.GameState
{
    public class GameStateController : MonoBehaviour
    {
        public static GameStateController Instance { get; private set; }

        [SerializeField] private GameState initState;   // 初期ゲーム状態
        public GameStateReactiveProperty CurrentGameState { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                CurrentGameState = new GameStateReactiveProperty(initState);
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // 現在のゲームの状態が変更されたときのイベント
            CurrentGameState
                .SkipLatestValueOnSubscribe()
                .Subscribe(state =>
                {
                    SceneUtil.SceneChange(state);
                }).AddTo(this);
        }

        public void ChangeToResult()
        {
            GetComponent<ScenePacks>().ResultPack();
            CurrentGameState.Value = GameState.Result;
        }

        // ゲームの状態を変更
        public void ChangeGameState(GameState state)
        {
            CurrentGameState.Value = state;
        }
    }
}