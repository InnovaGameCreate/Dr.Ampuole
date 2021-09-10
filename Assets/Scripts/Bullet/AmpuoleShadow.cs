using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Patient;
using UniRx;
using Player;

namespace Bullets
{
    public class AmpuoleShadow : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> sprites;
        [SerializeField]
        private PlayerBulletCount playerBulletCount;
        private Image image;
        private RectTransform rectTransform;
        private Quaternion initRotation;
        public AmpuoleState State { get; private set; } = AmpuoleState.Empty;
        private BulletType bulletType;

        private void Start()
        {
            image = transform.parent.GetComponent<Image>();
            rectTransform = transform.parent.GetComponent<RectTransform>();
            initRotation = rectTransform.localRotation;

            GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (!State.Equals(AmpuoleState.Empty))
                    {
                        image.sprite = sprites[0];
                        rectTransform.localRotation = initRotation;
                        playerBulletCount.ChangeBulletCount(bulletType);
                        State = AmpuoleState.Empty;
                    }
                }).AddTo(this);
        }

        public void Create(PatientType patientType)
        {
            switch (patientType)
            {
                case PatientType.Delta:
                    image.sprite = sprites[1];
                    rectTransform.Rotate(0,0,90);
                    bulletType = BulletType.Delta;
                    State = AmpuoleState.Delta;
                    return;
                case PatientType.Epsilon:
                    image.sprite = sprites[2];
                    rectTransform.Rotate(0,0,90);
                    bulletType = BulletType.Epsilon;
                    State = AmpuoleState.Epsilon;
                    return;
                case PatientType.Zeta:
                    image.sprite = sprites[3];
                    rectTransform.Rotate(0,0,90);
                    bulletType = BulletType.Zeta;
                    State = AmpuoleState.Zeta;
                    return;
                default:
                    image.sprite = sprites[0];
                    State = AmpuoleState.Empty;
                    bulletType = default;
                    rectTransform.localRotation = initRotation;
                    return;
            }
        }
    }
}