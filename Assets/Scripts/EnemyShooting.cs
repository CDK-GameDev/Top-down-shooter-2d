using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyShooting : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject enemyBulletPrefab;

        public void Shoot()
        {
            // Shooting logic
            Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}