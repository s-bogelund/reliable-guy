using System;
using UnityEngine;

namespace AI.FSM
{
    [CreateAssetMenu(menuName = "AI/FSM/Transition")] // This attribute allows us to create a new Transition asset in the project window
    public sealed class Transition : ScriptableObject
    {
        public Decision decision;
        public BaseState trueState; // i.e. the state to transition to if the decision is true
        public BaseState falseState; // i.e. the state to transition to if the decision is false

        public void Execute(BaseStateMachine stm)
        {
            if (decision.Decide(stm) && trueState is not RemainInState)
            {
                stm.CurrentState.Exit(stm);
                stm.CurrentState = trueState;
                stm.CurrentState.Enter(stm);
            }
            else if (falseState is not RemainInState)
            {
                stm.CurrentState.Exit(stm);
                stm.CurrentState = falseState;
                stm.CurrentState.Enter(stm);
            }
        }
    }
}