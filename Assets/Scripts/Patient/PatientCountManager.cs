using UnityEngine;
using UniRx;

namespace Patient
{
    public class PatientCountManager : MonoBehaviour
    {
        private ReactiveProperty<int> currentPatientCount = new ReactiveProperty<int>();
        public IReadOnlyReactiveProperty<int> CurrentPatientCount => currentPatientCount;

        private void Start()
        {

        }

        public void SetPatientCount(int count)
        {
            currentPatientCount.Value = count;
        }
    }
}