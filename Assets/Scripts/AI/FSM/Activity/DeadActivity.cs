using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/DeadActivity")]
    public class DeadActivity : Activity
    {
        public AudioClip deathClip = null;
        private EnemyState _enemyState;
        
        public override void Enter(BaseStateMachine stm)
        {
            _enemyState = stm.GetComponent<EnemyState>();
            // TODO: stm.GetComponent<AudioSource>().PlayOneShot(deathClip);
            Debug.Log("Entered DeadActivity");

        }

        public override void Execute(BaseStateMachine stm)
        {
            _enemyState.deadTimer += Time.deltaTime;
            if (_enemyState.deadTimer >= 1f)
            {
                Destroy(stm.GetComponentInParent<Transform>().gameObject);
            }
            else
            {
                stm.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Lerp(1, 0, _enemyState.deadTimer));
            }
            Debug.Log("Executing WaitActivity");

        }

        public override void Exit(BaseStateMachine stm)
        {
            Debug.Log("Exited WaitActivity");

        }
    }
}