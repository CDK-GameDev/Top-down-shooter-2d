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

            // Calculate the angle in degrees from the bullet's position to the target's position
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg - 90f;

            // Apply the rotation to the bullet
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            Destroy(gameObject, lifetime); // Schedule the bullet for destruction after 'lifetime' seconds.
        }

        void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Player"))
            {
                Destroy(hitInfo.transform.gameObject); // Destroy the player on collision.
                Destroy(gameObject); // Destroy the bullet on collision.
            }
        }
    }
}
