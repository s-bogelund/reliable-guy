using AI.FSM.Activity;
using UnityEngine;

namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decision/Reached Patrol Point", fileName = "ReachedPatrolPoint")]
    public class ReachedPatrolPointDecision: Decision
    {
        public override bool Decide(BaseStateMachine stm)
        {
            return stm.GetComponent<PatrolPoints>().HasReachedTargetPoint();
        }
    }
}