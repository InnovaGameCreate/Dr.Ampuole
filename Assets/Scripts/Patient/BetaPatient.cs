using UniRx;
using UniRx.Triggers;
using Bullets;

namespace Patient
{
    public class BetaPatient : BasePatient
    {
        protected override PatientType patientType => PatientType.Beta;

        private void Start()
        {
            SetRandomDestination();

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

        private void Update()
        {
            if (navMeshAgent.remainingDistance < 0.1f)
            {
                SetRandomDestination();
            }
        }
    }
}