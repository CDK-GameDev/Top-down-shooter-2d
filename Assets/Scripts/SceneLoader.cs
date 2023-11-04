using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int sceneIndexToLoad = 1;  // The index of the scene to load when the player dies

        private void OnEnable()
        {
            // Subscribe to the Player's death event
            Player.OnPlayerDeath += LoadScene;
        }

        private void OnDisable()
        {
            // Unsubscribe from the Player's death event
            Player.OnPlayerDeath -= LoadScene;
        }

        public void LoadScene()
        {
            SceneManager.LoadSceneAsync(sceneIndexToLoad, LoadSceneMode.Single);
        }
    }
}