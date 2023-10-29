using System.Collections;
using System.Collections.Generic;
using AI.FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/FSM/Activity/ChaseActivity")]
public class ChaseActivity : Activity
{
    GameObject target;     // target to chase
    public string targetTag = "Player";  // the tag of the target game object we want to check against
    public float speed = 1;  // how fast we should chase the target?

    public override void Enter(BaseStateMachine stateMachine)
    {
        target = GameObject.FindWithTag(targetTag);
        stateMachine.GetComponent<Animator>().SetFloat("moveSpeed", 1);

        // TODO: Look into changin movespeed into a bool here aswell
    }

    public override void Execute(BaseStateMachine stateMachine)
    {
        // TODO: Would it not be more performant to move these into the class instead of the Executo function?
        var RigidBody = stateMachine.GetComponent<Rigidbody2D>();
        var SpriteRenderer = stateMachine.GetComponent<SpriteRenderer>();

        Vector2 dir = (target.transform.position - stateMachine.transform.position).normalized;
        // TODO: Find out if the speed is inpamcted by computer performance, since deltaTime is not used
        RigidBody.velocity = new Vector2(dir.x * speed, RigidBody.velocity.y);
        SpriteRenderer.flipX = (dir.x > 0) ? true : false;
    }

    public override void Exit(BaseStateMachine stateMachine)
    {
    }
}
