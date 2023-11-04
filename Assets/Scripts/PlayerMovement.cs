using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Vector2 moveDirection;
        private Camera mainCamera;

        private void Start()
        {
            // Cache the main camera
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            // Handle movement based on the moveDirection which is set by OnMove method.
            transform.Translate(moveSpeed * Time.deltaTime * moveDirection);

            // Aim towards the mouse cursor
            AimTowardsMouse();
        }

        // This method is called by the Player Input component
        // when the movement action is performed
        public void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }

        private void AimTowardsMouse()
        {
            // Convert mouse position into world coordinates
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

            // Get the direction from the player to the mouse
            Vector2 direction = mouseWorldPosition - (Vector2)transform.position;

            // Calculate the angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the player's rotation to this angle, adjusted for sprite facing (assuming right-facing sprite)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
        }
    }

}