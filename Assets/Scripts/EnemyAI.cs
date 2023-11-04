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
        }

        private void MoveTowards()
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        }
    }

}