using UnityEngine;

namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/HitDecision")]
    public class HitDecision : Decision
    {
        public bool isHit = true;
        public override bool Decide(BaseStateMachine stm)
        {
            return stm.GetComponent<EnemyState>().isHit == isHit && !stm.GetComponent<EnemyState>().isDead;
        }
    }
}