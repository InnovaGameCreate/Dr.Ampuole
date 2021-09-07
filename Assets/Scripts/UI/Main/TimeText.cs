using UnityEngine;
using UnityEngine.UI;
using Systems;

namespace UI.Main
{
    public class TimeText : MonoBehaviour
    {
        private Text text;
        [SerializeField]
        private GameTime gameTime;

        private void Start()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            text.text = TimeFormat(gameTime.ElapsedTime);
        }

        private string TimeFormat(float time)
        {
            var minutes = Mathf.FloorToInt(time / 60.0f);
            var seconds = Mathf.FloorToInt(time - minutes * 60.0f);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}