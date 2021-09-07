using UnityEngine;

namespace Systems
{
    public class TimeResult : MonoBehaviour
    {
        public float ElapsedTimeResult { get; set; }

        private void Start()
        {
            Debug.Log(ElapsedTimeResult);
        }
    }
}