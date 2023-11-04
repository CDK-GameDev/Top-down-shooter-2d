using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemyPrefabs;
        [SerializeField] private float spawnRate = 1f;
        private float nextSpawnTime = 0f;

        void Update()
        {
            // Count the number of enemies currently in the scene
            var enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

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