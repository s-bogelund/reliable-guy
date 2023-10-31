using UnityEngine;

namespace AI.FSM.Decisions
{
    public abstract class Decision: ScriptableObject
    {
        public abstract bool Decide(BaseStateMachine stm);
    }
}