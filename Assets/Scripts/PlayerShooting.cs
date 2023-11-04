using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;

        // This method is called by the Player Input component
        // when the shooting action is performed
        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            // Shooting logic
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}