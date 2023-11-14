using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/Wait")]
    public class WaitActivity: Activity
    {
        public override void Enter(BaseStateMachine stm)
        {
            stm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            stm.GetComponent<Animator>().SetFloat("moveSpeed", 0);

            Debug.Log("Entered WaitActivity");

        }

        public override void Execute(BaseStateMachine stm)
        {
            // TODO maybe change direction of sprite 
            Debug.Log("Execute WaitActivity");

        }

        public override void Exit(BaseStateMachine stm)
        {
            Debug.Log("Exited WaitActivity");

        }
    }
}