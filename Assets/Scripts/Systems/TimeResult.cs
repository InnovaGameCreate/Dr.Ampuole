using UnityEngine;
using System;
namespace Systems
{
    public class TimeResult : MonoBehaviour
    {
        public float ElapsedTimeResult { get; set; }

        private void Start()
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(TimeSpan.FromSeconds(ElapsedTimeResult));
        }
    }
}