using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/AttackActivity")]
    public class AttackActivity : Activity
    {
        public float attackDelay = 3;
        private float _timer = 0;
        
        public override void Enter(BaseStateMachine stm)
        {
            stm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            var animator = stm.GetComponent<Animator>();
            animator.SetFloat("moveSpeed", 0);
            _timer = 2.5f;
        }

        public override void Execute(BaseStateMachine stm)
        {
            // This is left empty as the Attack animation is set to loop hence the ExecuteAttack function will be called repeatedly
            // If we wish a more random attack pattern, we can add a random timer here to call ExecuteAttack
            _timer += Time.deltaTime;
            Debug.Log(_timer);
            if (_timer >= attackDelay)
            {
                var animator = stm.GetComponent<Animator>();
                animator.SetTrigger("attack");
                
                _timer = 0;
            }
        }

        public override void Exit(BaseStateMachine stm)
        {
            stm.GetComponent<Animator>().Play("Idle");
        }
    }
}