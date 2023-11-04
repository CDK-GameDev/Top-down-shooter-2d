using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : BulletBase
    {
        // Start is called before the first frame update
        void Start()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            rb.velocity = direction * speed;
            Destroy(gameObject, lifetime); // Schedule the bullet for destruction after 'lifetime' seconds.
        }

        void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Enemy"))
            {
                Destroy(hitInfo.transform.gameObject); // Destroy the bullet on collision.
                Destroy(gameObject); // Destroy the bullet on collision.
            }
        }
    }
}