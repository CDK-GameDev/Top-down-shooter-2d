using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        private void OnEnable()
        {
            // Subscribe to the Player's death event
            Player.OnPlayerDeath += LoadScene;
            EnemySpawner.OnPlayerWin += LoadScene;
        }

        private void OnDisable()
        {
            // Unsubscribe from the Player's death event
            Player.OnPlayerDeath -= LoadScene;
            EnemySpawner.OnPlayerWin -= LoadScene;
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        }
    }
}