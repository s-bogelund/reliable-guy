using System.Collections.Generic;
using AI.FSM.Transitions;
using UnityEngine;

namespace AI.FSM.States
{
    [CreateAssetMenu(menuName = "AI/FSM/State/State")]
    // Once a class is defined as a sealed class, this class cannot be inherited
    public sealed class State: BaseState
    {
        public List<Activity.Activity> Activities = new List<Activity.Activity>();
        public List<Transition> Transitions = new List<Transition>();

        public override void Enter(BaseStateMachine stm)
        {
            foreach(var activity in Activities)
                activity.Enter(stm);
        }
        
        public override void Execute(BaseStateMachine stm)
        {
            foreach(var activity in Activities)
                activity.Execute(stm);
            foreach (var transition in Transitions)
                transition.Execute(stm);
        }
        
        public override void Exit(BaseStateMachine stm)
        {
            foreach(var activity in Activities)
                activity.Exit(stm);
        }
    }
}