using Unity.VisualScripting;
using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/Roam")]
    public class RoamActivity: Activity
    {
        public float roamMoveSpeed;
        
        public override void Enter(BaseStateMachine stm)
        {
            var patrolPoints = stm.GetComponent<PatrolPoints>();
            var animator = stm.GetComponent<Animator>();

            animator.SetFloat("moveSpeed", 1);
        }

        public override void Execute(BaseStateMachine stm)
        {
            var patrolPoints = stm.GetComponent<PatrolPoints>();
            var rigidBody = stm.GetComponent<Rigidbody2D>();
            Vector2 dir = patrolPoints.GetTargetPointDirection();
            var animator = stm.GetComponent<Animator>();
            animator.SetFloat("horizontal", dir.x);
            animator.SetFloat("vertical", dir.y);
            
            rigidBody.velocity = new Vector2(dir.x * roamMoveSpeed, dir.y * roamMoveSpeed);
        }

        public override void Exit(BaseStateMachine stm)
        {
            var patrolPoints = stm.GetComponent<PatrolPoints>();
            patrolPoints.SetNextPatrolPoint();
        }
    }
}