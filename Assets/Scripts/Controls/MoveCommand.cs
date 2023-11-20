using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/MoveCommand")]
    public class MoveCommand: BaseCommand
    {
        [Range(0, 10f)] [SerializeField] private float moveSpeed = 1f;
        
        private Vector2 moveDirection = Vector2.zero;

        public override void Execute(InputAction action, GameObject gameObject)
        {
            // Read the movement value
            moveDirection = action.ReadValue<Vector2>();
            
            // Play move animation
            var animator = gameObject.GetComponent<Animator>();
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (moveDirection != Vector2.zero)
            {
                if (moveDirection.x < 0)
                    spriteRenderer.flipX = true;
                else
                    spriteRenderer.flipX = false;
                
                animator.SetFloat("horizontal", moveDirection.x);
                animator.SetFloat("vertical", moveDirection.y);
                Debug.Log(moveDirection);
            }
            gameObject.GetComponent<Animator>().SetFloat("moveSpeed", moveDirection.sqrMagnitude);
        }
 
        public override void FixedExecute(InputAction action, GameObject gameObject)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            // Move the character
            if (moveDirection != Vector2.zero)
            {
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            }
            else
            {
                // Stop the character
                rb.velocity = Vector2.zero;
            }
        }
    }
}