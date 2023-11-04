using TMPro;
using UnityEngine;
namespace Assets.Scripts
{

    public class EnemiesLeft : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private TextMeshProUGUI enemiesLeftText;

        private void Start()
        {
            enemiesLeftText.text = $"Enemies left: {enemySpawner.EnemiesLeft}";
            EnemyBase.OnEnemyDestroyed += UpdateEnemiesLeft;
        }

        // Update is called once per frame
        void UpdateEnemiesLeft(int score)
        {
            enemySpawner.EnemiesLeft--;
            enemiesLeftText.text = $"Enemies left: {enemySpawner.EnemiesLeft}";
        }
    }

}