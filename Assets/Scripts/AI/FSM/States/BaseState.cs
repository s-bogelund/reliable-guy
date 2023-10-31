using UnityEngine;

namespace AI.FSM.States
{
    public class BaseState: ScriptableObject
    {
        public virtual void Enter(BaseStateMachine stm) { }
        public virtual void Execute(BaseStateMachine stm) { }
        public virtual void Exit(BaseStateMachine stm) { }
    }
}