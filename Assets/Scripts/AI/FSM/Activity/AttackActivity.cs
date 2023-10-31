using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/AttackActivity")]
    public class AttackActivity : Activity
    {
        GameObject target;     // target to chase
        public string targetTag = "Player";  // the tag of the target game object we want to check against
        public Vector2 playerPosition;
        public float speed = 0.5f;  // how fast we should chase the target?
        public float attackCooldownMs = 2f;
        public float attackDelay = 2f;
        public float attackMoveSpeed = 1.5f;
        MonoBehaviour mono; // Used to be able to use Co-routines

        float timeBetweenAttacks = 3f;
        private float timer = 0f;

        public override void Enter(BaseStateMachine stm)
        {
            Debug.Log("Enter AttackActivity");
            mono = stm.GetComponent<MonoBehaviour>();
            var SpriteRenderer = stm.GetComponent<SpriteRenderer>();
            SpriteRenderer.color = Color.red;
            target = GameObject.FindWithTag(targetTag);
            stm.GetComponent<Animator>().SetFloat("moveSpeed", 1);
            // TODO: Look into changin movespeed into a bool here aswell
            playerPosition = target.transform.position; // Setting position in Enter, as we want enemy to lunge at the players position in the moment it transitions, with a small delay, so that the player can move away
        }

        public override void Execute(BaseStateMachine stm)
        {
            timer += Time.deltaTime;
            // TODO: Issue is that Enter is called more often than Execute should be called resetting the timer
            if (timer >= timeBetweenAttacks)
            {
                timer = 0f;
                mono.StartCoroutine(AttackCoroutine(stm));
            }
            // Might need to force the transition to another state, because position will not update, unless Enter is run again
            // Could also try to move position to Execute, but i think the enemy will become a homing missile
        }

        public override void Exit(BaseStateMachine stm)
        {
            var SpriteRenderer = stm.GetComponent<SpriteRenderer>();
            SpriteRenderer.color = Color.white;
        }

        IEnumerator AttackCoroutine(BaseStateMachine stm)
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(attackDelay);

            Attack(stm);
        }

        public void Attack(BaseStateMachine stm)
        {
            // TODO: Would it not be more performant to move these into the class instead of the Executo function?
            var RigidBody = stm.GetComponent<Rigidbody2D>();
            var SpriteRenderer = stm.GetComponent<SpriteRenderer>();

            Vector2 dir = (target.transform.position - stm.transform.position).normalized;
            // TODO: Find out if the speed is inpamcted by computer performance, since deltaTime is not used
            RigidBody.velocity = new Vector2(dir.x * attackMoveSpeed, dir.y * attackMoveSpeed);
            SpriteRenderer.flipX = (dir.x > 0) ? true : false;
        }
    }
}