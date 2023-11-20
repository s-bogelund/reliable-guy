using Unity.VisualScripting;
using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/Patrol")]
    public class PatrolActivity: Activity
    {
        public float patrolMoveSpeed = 0.25f;
        
        public override void Enter(BaseStateMachine stm)
        {
            var patrolPoints = stm.GetComponent<PatrolPoints>();
            var spriteRenderer = stm.GetComponent<SpriteRenderer>();
            var animator = stm.GetComponent<Animator>();

            stm.GetComponent<EnemyState>().flipSprite(patrolPoints.GetTargetPointDirection().x);
            animator.SetFloat("moveSpeed", 1);
        }

        public override void Execute(BaseStateMachine stm)
        {
            var patrolPoints = stm.GetComponent<PatrolPoints>();
            var rigidBody = stm.GetComponent<Rigidbody2D>();
            var spriteRenderer = stm.GetComponent<SpriteRenderer>();
            Vector2 dir = patrolPoints.GetTargetPointDirection();
            
            rigidBody.velocity = new Vector2(dir.x * patrolMoveSpeed, dir.y * patrolMoveSpeed);
        }

        public override void Exit(BaseStateMachine stm)
        {
            var patrolPoints = stm.GetComponent<PatrolPoints>();
            patrolPoints.SetNextPatrolPoint();
        }
    }
}