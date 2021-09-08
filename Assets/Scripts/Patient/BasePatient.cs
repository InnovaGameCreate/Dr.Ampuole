using UnityEngine;
using UnityEngine.AI;

namespace Patient
{
    public abstract class BasePatient : MonoBehaviour
    {
        protected NavMeshAgent navMeshAgent;
        protected Transform movePoints;

        private void Awake()
        {
            movePoints = GameObject.FindGameObjectWithTag("MovePoints").transform;
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        protected void SetRandomDestination()
        {
            var i = Random.Range(0, movePoints.childCount);
            navMeshAgent.destination = movePoints.GetChild(i).position;
        }

        protected abstract PatientType patientType { get; }
    }
}