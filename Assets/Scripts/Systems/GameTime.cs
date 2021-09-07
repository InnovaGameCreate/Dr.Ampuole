using UnityEngine;
using UniRx;
using Systems.GameState;

namespace Systems
{
    public class GameTime : MonoBehaviour
    {
        public float ElapsedTime { get; private set; }
        private bool isMesure = false;

        private void Start()
        {
            GameStateController.Instance.CurrentGameState
                .Where(state => state == GameState.GameState.Main)
                .Subscribe(_ =>
                {
                    isMesure = true;
                }).AddTo(this);
        }

        private void FixedUpdate()
        {
            if (isMesure)
            {
                ElapsedTime += Time.deltaTime;
            }
        }
    }
}