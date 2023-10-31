using UnityEngine;

namespace AI.FSM.Activity
{
    public abstract class Activity : ScriptableObject
    {
        public abstract void Enter(BaseStateMachine stm);
        public abstract void Execute(BaseStateMachine stm);
        public abstract void Exit(BaseStateMachine stm);
    }
}