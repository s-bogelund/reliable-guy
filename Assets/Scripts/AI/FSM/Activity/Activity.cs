using UnityEngine;

namespace AI.FSM
{
    public abstract class Activity : ScriptableObject
    {
        public abstract void Enter(BaseStateMachine stm);
        public abstract void Execute(BaseStateMachine stm);
        public abstract void Exit(BaseStateMachine stm);
    }
}