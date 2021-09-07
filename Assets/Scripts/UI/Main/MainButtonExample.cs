using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using Systems;
using Systems.GameState;

namespace UI.Title
{
    public class MainButtonExample : MonoBehaviour
    {
        private Button button;
        [SerializeField]
        private GameTime gameTime;

        private void Start()
        {
            button = GetComponent<Button>();

            button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    SceneManager.sceneLoaded += ResultSceneLoaded;
                    GameStateController.Instance.ChangeGameState(GameState.Result);
                }).AddTo(this);
        }

        private void ResultSceneLoaded(Scene next, LoadSceneMode mode)
        {
            var tr = GameObject.FindGameObjectWithTag("TimeResult").GetComponent<TimeResult>();
            tr.ElapsedTimeResult = gameTime.ElapsedTime;
            SceneManager.sceneLoaded -= ResultSceneLoaded;
        }
    }
}