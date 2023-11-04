using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        private Transform playerTarget;

        void Start()
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            MoveTowards();
            LookAtPlayer();
        }

        private void MoveTowards()
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        }


        private void LookAtPlayer()
        {
            // Calculate the direction vector from the enemy to the player
            Vector2 direction = (playerTarget.position - transform.position).normalized;

            // Calculate the angle from the enemy to the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the enemy's rotation towards the player
            // If your sprite's default facing direction is to the right (which is the usual case), 
            // you don't need to add any offset to the angle
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90)); // Subtract 90 if sprite's up is the default front
        }
    }

}