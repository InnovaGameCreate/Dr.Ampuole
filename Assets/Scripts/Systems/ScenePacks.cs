using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class ScenePacks : MonoBehaviour
    {
        private GameTime gameTime;

        public void ResultPack()
        {
            gameTime = GameObject.Find("GameTime").GetComponent<GameTime>();
            SceneManager.sceneLoaded += ResultSceneLoaded;
        }

        private void ResultSceneLoaded(Scene next, LoadSceneMode mode)
        {
            var tr = GameObject.FindGameObjectWithTag("TimeResult").GetComponent<TimeResult>();
            tr.ElapsedTimeResult = gameTime.ElapsedTime;
            Cursor.visible = true;
            SceneManager.sceneLoaded -= ResultSceneLoaded;
        }
    }
}