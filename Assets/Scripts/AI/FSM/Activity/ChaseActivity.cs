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
            Debug.Log(target.tag);
            stateMachine.GetComponent<Animator>().SetFloat("moveSpeed", 1);
            Debug.Log("ChaseActivity Enter");

        }

        public override void Execute(BaseStateMachine stateMachine)
        {
            // TODO: Would it not be more performant to move these into the class instead of the Execute function? I agree - Jacob
            var RigidBody = stateMachine.GetComponent<Rigidbody2D>();

            Vector2 dir = (target.transform.position - stateMachine.transform.position).normalized;
            // TODO: Find out if the speed is inpamcted by computer performance, since deltaTime is not used
            RigidBody.velocity = new Vector2(dir.x * speed, dir.y * speed);
            stateMachine.GetComponent<EnemyState>().flipSprite(dir.x);
        }

        public override void Exit(BaseStateMachine stateMachine)
        {
            Debug.Log("ChaseActivity Exit");
        }
    }
}
