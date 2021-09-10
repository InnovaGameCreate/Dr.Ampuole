using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Patient;
using UniRx;
using UniRx.Triggers;

namespace Bullets
{
    public class AmpuoleShadow : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> sprites;
        private Image image;
        private RectTransform rectTransform;
        private Quaternion initRotation;
        public AmpuoleState State { get; private set; } = AmpuoleState.Empty;

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
                    rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
                    State = AmpuoleState.Delta;
                    return;
                case PatientType.Epsilon:
                    image.sprite = sprites[2];
                    rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
                    State = AmpuoleState.Epsilon;
                    return;
                case PatientType.Zeta:
                    image.sprite = sprites[3];
                    rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
                    State = AmpuoleState.Zeta;
                    return;
                default:
                    image.sprite = sprites[0];
                    State = AmpuoleState.Empty;
                    rectTransform.localRotation = initRotation;
                    return;
            }
        }
    }
}