using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/DeadActivity")]
    public class DeadActivity : Activity
    {
        public AudioClip deathClip = null;
        private EnemyState _enemyState;
        public float dampingFactor;
        
        public override void Enter(BaseStateMachine stm)
        {
            _enemyState = stm.GetComponent<EnemyState>();
            stm.GetComponent<Animator>().SetTrigger("Defeated");
            
            if (stm.gameObject.name == "Cacodaemon")
            {
                BossDoorController[] bossDoorControllers = GameObject.FindObjectsOfType<BossDoorController>();
                foreach(BossDoorController controller in bossDoorControllers)
                {
                    controller.OpenDoor();
                }
            }
            
            // TODO: stm.GetComponent<AudioSource>().PlayOneShot(deathClip);
        }

        public override void Execute(BaseStateMachine stm)
        {
            _enemyState.deadTimer += Time.deltaTime;
            if (_enemyState.deadTimer >= 5f)
            {
                Destroy(stm.GetComponentInParent<Transform>().gameObject);
            }
            else
            {
                Rigidbody2D rb = stm.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * dampingFactor);

                stm.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Lerp(1, 0, _enemyState.deadTimer / 5f));
            }
        }

        public override void Exit(BaseStateMachine stm)
        {
        }
    }
}