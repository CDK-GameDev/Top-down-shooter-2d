using UnityEngine;

namespace Assets.Scripts
{
    public class BulletBase : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected float speed = 20f;
        [SerializeField] protected float lifetime = 5f; // bullet's lifetime in seconds
    }
}