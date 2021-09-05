using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Systems.GameState;

namespace UI.Title
{
    public class TitleButtonExample : MonoBehaviour
    {
        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();

            button.OnClickAsObservable()
                .Subscribe(_ => GameStateController.Instance.ChangeGameState(GameState.Main))
                .AddTo(this);
        }
    }
}