using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
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
    public float damage = 1f;
    
    private int _executionNumber = 0;
    
    // TODO: Add audioclip for when enemy is hit and attacks

    public void ExecuteAttack()
    {
        // TODO: Play sound effect
        
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
                throw new System.NotImplementedException();
                // TODO: GameManager.instance.substractHP(damage);
            }
        }
    }

    public void ResetAttack()
    {
        _executionNumber = 0;
    }
    
}
