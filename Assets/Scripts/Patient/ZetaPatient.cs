using UniRx;
using UniRx.Triggers;
using Bullets;
using Systems.Audio;

namespace Patient
{
    public class ZetaPatient : BasePatient
    {
        protected override PatientType patientType => PatientType.Zeta;

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
                            patientManager.SetPatientCount(patientManager.CurrentPatientCount.Value - 1);
                            Destroy(gameObject);
                            SeManager.Instance.ShotSe(SeType.Heal);
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