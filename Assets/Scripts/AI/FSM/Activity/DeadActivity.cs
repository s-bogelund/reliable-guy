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
        }

        public override void Exit(BaseStateMachine stm)
        {
        }
    }
}