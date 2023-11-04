using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public static event System.Action<int> OnPlayerDeath;

        void OnTriggerEnter2D(Collider2D hitInfo)
        {
            // Check if the player is hit by an enemy or an enemy's bullet
            if (hitInfo.CompareTag("Enemy"))
            {
                Die();
            }
        }

        void Die()
        {
            // Logic for player's death
            Debug.Log("Player died!");
            OnPlayerDeath?.Invoke(3);

            Destroy(gameObject);  // Example action: Destroy the player object
        }
    }
}
