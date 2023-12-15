
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int HP;
    public int maxHP;
    public bool isHit;
    public bool isDead;
    public float hitTimer;
    public float deadTimer;
    public Vector2 hitDir;
    public Rigidbody2D RigidBody;
    public float attackRange = 0.25f;
    public int damage = 1;
    
    private int _executionNumber = 0;
    
    // TODO: Add audioclip for when enemy is hit and attacks

    public void ExecuteAttack()
    {
        // TODO: Play sound effect
        Debug.Log("Enemy attacks!");
        
        _executionNumber++;
        if (_executionNumber == 1)
        {
            // Stop slime
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            // Check if player is in range
            Collider2D[] hitTarget = Physics2D.OverlapCircleAll(transform.GetChild(0).position, attackRange, enemyLayer);

            // hitTarget[0] is the player due to enemyLayer
            if (hitTarget.Length > 0 && hitTarget[0] != null)
            {
                GameManager.Instance.substractHP(damage);
            }
        }
    }

    public void ResetAttack()
    {
        _executionNumber = 0;
    }

    public void flipSprite(float xDir)
    {
        if ((xDir > 0 && transform.localScale.x != 1) ||
            (xDir < 0 && transform.localScale.x != -1))
        {
            Vector3 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;
        }
    }
    
}
