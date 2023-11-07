using System.Collections;
using System.Collections.Generic;
using Characters.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving
    {
        set
        {
            _isMoving = value;
            _animator.SetBool("isMoving", value);
        }
        get => _isMoving;
    }
    
    public float moveSpeed = 1f; // Public so that we can see it in the Unity inspector
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public static Vector2? NextInitialPosition;
    
    private Vector2 _movementInput;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>(); // Raycast is use to check if a move i valid before we perform the move (i.e. not valid if you try to go through a wall)

    private bool _isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>(); // This is basically the way you access components of the game object
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (!NextInitialPosition.HasValue) return;
        _rb2d.position = NextInitialPosition.Value;
        NextInitialPosition = null; 
    }

    private void FixedUpdate()
    {
        bool moveSuccessful = false;
        // If movement vector is not zero
        if (_movementInput != Vector2.zero)
        {
            moveSuccessful = TryMove(_movementInput);

            if (!moveSuccessful)
            {
                moveSuccessful = TryMove(new Vector2(_movementInput.x, 0));

                if (!moveSuccessful)
                {
                    moveSuccessful = TryMove(new Vector2(0, _movementInput.y));
                }
            }
        }

        if (moveSuccessful)
        {
            // Set direction of sprite to movement direction
            if (_movementInput.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
            _animator.SetFloat("horizontal", _movementInput.x);
            _animator.SetFloat("vertical", _movementInput.y);
        }
        
        // Finally set movespeed this helps transition between idle or move
        _animator.SetFloat("moveSpeed", _movementInput.sqrMagnitude);
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Move the player
            int count = _rb2d.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction of movement and to look for colisions
                movementFilter, // Settings that determine where a collision can occur and what layers to ignore
                _castCollisions, // List of collisions to store the found collisions into after the Cast is complete
                moveSpeed * Time.fixedDeltaTime + collisionOffset // Amount to cast equal to the movement speed plus a small offset
            );
    
            if (count == 0)
            {
                _rb2d.MovePosition(_rb2d.position + direction * (moveSpeed * Time.fixedDeltaTime)); // Fixed update in Unity means that there's a Fixed number frames per sec where physics updates take place. Fixed is easier than variable frames. 
                return true;
            }
        }

        return false;
    }

    void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    // Attack
    void OnFire()
    {
        _animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {
        if (_spriteRenderer.flipX)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }
    
    public void EndSwordAttack()
    {
        swordAttack.StopAttack();
    }
    public static void SetNextInitialPosition(Vector2 position)
    {
        NextInitialPosition = position;
    }
    

}
