using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Systems.GameState;

namespace UI.Result
{
    public class ResultButtonExample : MonoBehaviour
    {
        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();

            button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    GameStateController.Instance.ChangeGameState(GameState.Title);
                }).AddTo(this);
        }
    }
}