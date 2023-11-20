using UnityEngine;

namespace AI.FSM.Activity
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/StunnedActivity")]
    public class StunnedActivity : Activity
    {
        public AudioClip hitClip = null;
        public float hitInvincibilityTime = 1f, hitAnimationSpeed = 1f;
        
        EnemyState _enemyState;
        
        public override void Enter(BaseStateMachine stm)
        {
            _enemyState = stm.GetComponent<EnemyState>();
            
            // TODO: stm.GetComponent<AudioSource>().PlayOneShot(hitClip);
            stm.GetComponent<Animator>().SetTrigger("hit");
            stm.GetComponent<Rigidbody2D>().AddForce(new Vector2(_enemyState.hitDir.x, _enemyState.hitDir.y) * 3f, ForceMode2D.Impulse);
        }

        public override void Execute(BaseStateMachine stm)
        {
            if (_enemyState.isHit)
            {
                _enemyState.hitTimer += Time.deltaTime;
                if (_enemyState.hitTimer >= hitInvincibilityTime)
                {
                    _enemyState.HP -= 1;
                    _enemyState.hitTimer = 0f;
                    _enemyState.isHit = false;
                    if (_enemyState.HP <= 0)
                    {
                        _enemyState.isDead = true;
                    }
                }
            }
        }

        public override void Exit(BaseStateMachine stm)
        {
        }
    }
}