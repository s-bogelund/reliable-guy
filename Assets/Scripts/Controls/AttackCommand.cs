using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/AttackCommand")]
    public class AttackCommand : BaseCommand
    {
        public LayerMask enemyLayer;
        private bool _attack = false;
        private int _executionNumber = 0;
        public float attackRange = 0.25f;
        private bool _alreadyPlayedAnimation = false;

        public AudioClip swingClip;

        private GameObject _gameObject = null;
        
        public override void Execute(InputAction action, GameObject gameObject)
        {
            if (!_gameObject)
                _gameObject = gameObject;
            if (action.WasPressedThisFrame())
            {
                _attack = true;
            }

            if (_attack && !_alreadyPlayedAnimation)
            {
                _alreadyPlayedAnimation = true;
                _gameObject.GetComponent<Animator>().SetTrigger("swordAttack");
            }
        }
        
        public override void FixedExecute(InputAction action, GameObject gameObject)
        {
            if (!_gameObject)
                _gameObject = gameObject;
        }

        public void ExecuteAttack()
        {
            if (_attack)
            {
                _gameObject.GetComponent<AudioSource>().PlayOneShot(swingClip, 0.15f);

                _executionNumber++;
                // Make sure the attack is only executed once, and can't be executed before the animation resets
                if (_executionNumber == 1)
                {
                    _gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Collider2D[] hitTargets = Physics2D.OverlapCircleAll(_gameObject.transform.GetChild(0).position, attackRange, enemyLayer);

                    foreach (Collider2D hitTarget in hitTargets)
                    {
                        hitTarget.GetComponent<EnemyState>().hitDir = hitTarget.transform.position - _gameObject.transform.position;
                        hitTarget.GetComponent<EnemyState>().isHit = true;
                    }
                }
            }
        }
        
        public void ResetAttack()
        {
            _alreadyPlayedAnimation = false;
            _attack = false;
            _executionNumber = 0;
        }

    }
}