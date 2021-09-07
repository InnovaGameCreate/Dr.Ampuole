using UniRx;
using UniRx.Triggers;
using Bullets;

namespace Patient
{
    public class GammaPatient : BasePatient
    {
        protected override PatientType patientType => PatientType.Gamma;

        private void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Subscribe(col =>
                {
                    if (col.TryGetComponent(out Bullet b))
                    {
                        if (b.bulletType.ToString() == patientType.ToString())
                        {
                            Destroy(gameObject);
                        }
                        Destroy(col.gameObject);
                    }
                }).AddTo(this);
        }
    }
}