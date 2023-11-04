using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : BulletBase
    {
        void Start()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            rb.velocity = direction * speed;

            // Calculate the angle in degrees from the bullet's position to the mouse position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            // Apply the rotation to the bullet
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            Destroy(gameObject, lifetime); // Schedule the bullet for destruction after 'lifetime' seconds.
        }

        void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Enemy"))
            {
                Destroy(hitInfo.transform.gameObject); // Destroy the enemy on collision.
                Destroy(gameObject); // Destroy the bullet on collision.
            }
        }
    }
}
