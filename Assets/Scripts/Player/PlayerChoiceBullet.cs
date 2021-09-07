using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Bullets;

namespace Player
{
    public class PlayerChoiceBullet : MonoBehaviour
    {
        private ReactiveProperty<BulletType> currentBulletType;
        public IReadOnlyReactiveProperty<BulletType> CurrentBulletType => currentBulletType;

        private void Awake()
        {
            currentBulletType = new ReactiveProperty<BulletType>(BulletType.Alpha);

            this.UpdateAsObservable()
                .Select(_ => Input.mouseScrollDelta.y)
                .Where(delta => delta != 0)
                .Subscribe(ChangeBulletType)
                .AddTo(this);
        }

        private void ChangeBulletType(float delta)
        {
            var bt = currentBulletType.Value;
            if (bt.Equals(BulletType.Alpha))
            {
                if (delta == 1)
                {
                    currentBulletType.Value = BulletType.Zeta;
                }
                else
                {
                    currentBulletType.Value = bt - (int)delta;
                }
            }
            else if (bt.Equals(BulletType.Zeta))
            {
                if (delta == -1)
                {
                    currentBulletType.Value = BulletType.Alpha;
                }
                else
                {
                    currentBulletType.Value = bt - (int)delta;
                }
            }
            else
            {
                currentBulletType.Value = bt - (int)delta;
            }
        }
    }
}