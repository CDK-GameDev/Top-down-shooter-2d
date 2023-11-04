using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemyPrefabs;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int enemiesLeft = 4;

        public static event System.Action<int> OnPlayerWin;

        private float nextSpawnTime = 0f;
        public int EnemiesLeft
        {
            get { return enemiesLeft; }
            set { enemiesLeft = value; }
        }

        void Update()
        {
            // Count the number of enemies currently in the scene
            var enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemiesLeft == 0)
            {
                OnPlayerWin?.Invoke(2);
                Debug.Log("YOU WIN!");
            }

            if (Time.time >= nextSpawnTime && enemyCount < 2)
            {
                SpawnEnemy();
                nextSpawnTime = Time.time + 1f / spawnRate;
            }
        }

        void SpawnEnemy()
        {
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            // Instantiate enemy at random position (example)
            Instantiate(randomEnemyPrefab, transform.position, Quaternion.identity);
        }
    }
}