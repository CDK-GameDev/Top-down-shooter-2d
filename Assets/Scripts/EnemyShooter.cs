using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private float shootRate = 2f;  // Shoots every 2 seconds by default
        [SerializeField] private EnemyShooting enemyShooting;

        public void Start()
        {
            // Shooting logic
            InvokeRepeating(nameof(Shoot), shootRate, shootRate);
        }

        public void Shoot()
        {
            enemyShooting.Shoot();
        }
    }
}