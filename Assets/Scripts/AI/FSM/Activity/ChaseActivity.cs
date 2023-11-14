using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/ChaseActivity")]
    public class ChaseActivity : Activity
    {
        GameObject target;     // target to chase
        public string targetTag = "Player";  // the tag of the target game object we want to check against
        public float speed = 0.5f;  // how fast we should chase the target?

        public override void Enter(BaseStateMachine stateMachine)
        {
            target = GameObject.FindWithTag(targetTag);
            stateMachine.GetComponent<Animator>().SetFloat("moveSpeed", 1);

            // TODO: Look into changin movespeed into a bool here aswell
            Debug.Log("Entered ChaseActivity");

        }

        public override void Execute(BaseStateMachine stateMachine)
        {
            // TODO: Would it not be more performant to move these into the class instead of the Execute function? I agree - Jacob
            var RigidBody = stateMachine.GetComponent<Rigidbody2D>();
            var SpriteRenderer = stateMachine.GetComponent<SpriteRenderer>();

            Vector2 dir = (target.transform.position - stateMachine.transform.position).normalized;
            // TODO: Find out if the speed is inpamcted by computer performance, since deltaTime is not used
            RigidBody.velocity = new Vector2(dir.x * speed, dir.y * speed);
            stateMachine.GetComponent<EnemyState>().flipSprite(dir.x);
            Debug.Log("Executing ChaseActivity");

        }

        public override void Exit(BaseStateMachine stateMachine)
        {
            Debug.Log("Exited ChaseActivity");
        }
    }
}
