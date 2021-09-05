using UnityEngine.SceneManagement;

namespace Systems.GameState
{
    public static class SceneUtil
    {
        public static void SceneChange(GameState state)
        {
            var scene = state.ToString();
            SceneManager.LoadSceneAsync(scene);
        }
    }
}