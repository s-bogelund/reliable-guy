using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/RoamActivity")]
    public class RoamActivity : Activity
    {
        private Rigidbody2D _rb2d;
        private Animator _animator;
        
        public override void Enter(BaseStateMachine stateMachine)
        {
            _rb2d = stateMachine.GetComponent<Rigidbody2D>();
            _animator = stateMachine.GetComponent<Animator>();

            _rb2d.velocity = Vector2.zero;
            _animator.SetFloat("moveSpeed", 0);
            // TODO: Movespeed float should probably be changed to a boolean, as the value of movespeed has no effect other than if it is above 0 or not.
            // Make sure nothing else is bound up on moveSpeed being a float
        }

        public override void Execute(BaseStateMachine stateMachine)
        {
        }

        public override void Exit(BaseStateMachine stateMachine)
        {
        }
    }
}
