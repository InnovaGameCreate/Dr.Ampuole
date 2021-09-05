using System;
using UniRx;

namespace Systems.GameState
{
    [Serializable]
    public class GameStateReactiveProperty : ReactiveProperty<GameState>
    {
        public GameStateReactiveProperty() { }
        public GameStateReactiveProperty(GameState initValue) : base(initValue) { }
    }
}