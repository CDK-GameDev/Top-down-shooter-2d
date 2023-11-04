using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Vector2 moveDirection;

        // Update is called once per frame
        void Update()
        {
            // Handle movement based on the moveDirection which is set by OnMove method.
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

        // This method is called by the Player Input component
        // when the movement action is performed
        public void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

}