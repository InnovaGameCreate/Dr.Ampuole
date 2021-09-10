using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Patient;

namespace Bullets
{
    public class Ampuole : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> sprites;
        [SerializeField]
        private AmpuoleShadow ampuoleShadow;
        private Image image;
        private AmpuoleState state = AmpuoleState.Empty;

        private void Start()
        {
            image = transform.parent.GetComponentInParent<Image>();
        }

        public void Pour(PatientType patientType)
        {
            if (ampuoleShadow.State != AmpuoleState.Empty)
                return;

            switch (patientType)
            {
                case PatientType.Alpha:
                    if (state.Equals(AmpuoleState.Empty) || state.Equals(AmpuoleState.Alpha))
                    {
                        image.sprite = sprites[1];
                        state = AmpuoleState.Alpha;
                    }
                    else
                    {
                        image.sprite = sprites[0];
                        Create(patientType);
                        state = AmpuoleState.Empty;
                    }
                    return;
                case PatientType.Beta:
                    if (state.Equals(AmpuoleState.Empty) || state.Equals(AmpuoleState.Beta))
                    {
                        image.sprite = sprites[2];
                        state = AmpuoleState.Beta;
                    }
                    else
                    {
                        image.sprite = sprites[0];
                        Create(patientType);
                        state = AmpuoleState.Empty;
                    }
                    return;
                case PatientType.Gamma:
                    if (state.Equals(AmpuoleState.Empty) || state.Equals(AmpuoleState.Gumma))
                    {
                        image.sprite = sprites[3];
                        state = AmpuoleState.Gumma;
                    }
                    else
                    {
                        image.sprite = sprites[0];
                        Create(patientType);
                        state = AmpuoleState.Empty;
                    }
                    return;
                default:
                    return;
            }
        }

        private void Create(PatientType patientType)
        {
            switch (patientType)
            {
                case PatientType.Alpha:
                    if (state == AmpuoleState.Beta)
                    {
                        ampuoleShadow.Create(PatientType.Delta);
                    }
                    else if (state == AmpuoleState.Gumma)
                    {
                        ampuoleShadow.Create(PatientType.Epsilon);
                    }
                    return;
                case PatientType.Beta:
                    if (state == AmpuoleState.Alpha)
                    {
                        ampuoleShadow.Create(PatientType.Delta);
                    }
                    else if (state == AmpuoleState.Gumma)
                    {
                        ampuoleShadow.Create(PatientType.Zeta);
                    }
                    return;
                case PatientType.Gamma:
                    if (state == AmpuoleState.Alpha)
                    {
                        ampuoleShadow.Create(PatientType.Epsilon);
                    }
                    else if (state == AmpuoleState.Beta)
                    {
                        ampuoleShadow.Create(PatientType.Zeta);
                    }
                    return;
                default:
                    return;
            }
        }
    }

    public enum AmpuoleState
    {
        Empty,
        Alpha,
        Beta,
        Gumma,
        Delta,
        Epsilon,
        Zeta
    }
}