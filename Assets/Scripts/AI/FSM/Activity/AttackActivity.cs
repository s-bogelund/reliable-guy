using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/AttackActivity")]
    public class AttackActivity : Activity
    {
        public override void Enter(BaseStateMachine stm)
        {
            stm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            stm.GetComponent<Animator>().Play("Attack"); // TODO: I don't think this is the right way to do this
            Debug.Log("Entered AttackActivity");
        }

        public override void Execute(BaseStateMachine stm)
        {
            // This is left empty as the Attack animation is set to loop hence the ExecuteAttack function will be called repeatedly
            // If we wish a more random attack pattern, we can add a random timer here to call ExecuteAttack
        }

        public override void Exit(BaseStateMachine stm)
        {
            stm.GetComponent<Animator>().Play("Idle");
            Debug.Log("Exited AttackActivity");
        }
    }
}