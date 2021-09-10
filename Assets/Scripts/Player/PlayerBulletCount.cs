using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using Bullets;

namespace Player
{
    public class PlayerBulletCount : MonoBehaviour
    {
        private Subject<BulletType> subject = new Subject<BulletType>();
        public IObservable<BulletType> OnBulletsCountChanged => subject;

        private const int IncreseBullets = 5;
        public int DeltaBullets { get; set; } = 0;
        public int EpsilonBullets { get; set; } = 0;
        public int ZetaBullets { get; set; } = 0;

        private void Start()
        {
            OnBulletsCountChanged
                .Subscribe(bt =>
                {
                    switch (bt)
                    {
                        case BulletType.Delta:
                            DeltaBullets += 5;
                            return;
                        case BulletType.Epsilon:
                            EpsilonBullets += 5;
                            return;
                        case BulletType.Zeta:
                            ZetaBullets += 5;
                            return;
                    }
                }).AddTo(this);
        }

        public void ChangeBulletCount(BulletType type)
        {
            subject.OnNext(type);
        }

        private void OnDestroy()
        {
            subject.OnCompleted();
        }
    }
}