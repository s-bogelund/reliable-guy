using UnityEngine;

namespace Characters.Player
{
    public class SwordAttack : MonoBehaviour
    {
        private Vector2 downAttackOffset;
        public BoxCollider2D swordCollider;
        public float damage = 3;
    
        // Start is called before the first frame update
        void Start()
        {
            downAttackOffset = transform.position;
        }
    
        public void AttackRight()
        {
            print("Attack Right");
            swordCollider.enabled = true;
            transform.localPosition = new Vector2(0.1f, -0.1f);
        }
    
        public void AttackLeft()
        {
            print("Attack Left");
            swordCollider.enabled = true;
            transform.localPosition = new Vector2(-0.1f, 0.1f);
        }
    
        public void AttackUp()
        {
            swordCollider.enabled = true;
            transform.localPosition = new Vector3(downAttackOffset.x, downAttackOffset.y * -1);
        }
    
        public void AttackDown()
        {
            swordCollider.enabled = true;
            transform.localPosition = downAttackOffset;
        }

        public void StopAttack()
        {
            swordCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                // deal damage to enemy
                Enemy enemy = other.GetComponent<Enemy>();
            
                if (enemy != null)
                {
                    enemy.Health -= damage;
                }
            }
        }
    }
}