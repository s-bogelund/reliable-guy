using System.Collections;
using System.Collections.Generic;
using AI.FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/FSM/Activity/RoamActivity")]
public class RoamActivity : Activity
{
    public override void Enter(BaseStateMachine stateMachine)
    {
        stateMachine.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        stateMachine.GetComponent<Animator>().SetFloat("moveSpeed", 0);
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
