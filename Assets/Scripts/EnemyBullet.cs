
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyBullet : BulletBase
    {
        // Start is called before the first frame update
        void Start()
        {
            var target = GameObject.FindGameObjectWithTag("Player").transform;

            // Set the bullet's direction towards the player
            Vector2 shootDirection = (target.position - transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = shootDirection * speed;
            Destroy(gameObject, lifetime); // Schedule the bullet for destruction after 'lifetime' seconds.
        }

        void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Player"))
            {
                Destroy(hitInfo.transform.gameObject); // Destroy the bullet on collision.
                Destroy(gameObject); // Destroy the bullet on collision.
            }
        }
    }
}
