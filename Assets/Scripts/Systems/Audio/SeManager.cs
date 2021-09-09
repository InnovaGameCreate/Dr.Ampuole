using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Systems.Audio
{
    public class SeManager : MonoBehaviour
    {
        public static SeManager Instance { get; private set; }
        private AudioSource audioSource;

        [SerializeField]
        private List<AudioClip> seLists;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                audioSource = GetComponent<AudioSource>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ShotSe(SeType type)
        {
            Debug.Log("aaa");
            AudioClip clip = null;
            clip = seLists.FirstOrDefault(se => se.name.Equals(type.ToString()));

            if (clip != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}