using System.Collections.Generic;

namespace AI.FSM
{
    // Once a class is defined as a sealed class, this class cannot be inherited
    public sealed class State: BaseState
    {
        public List<Activity> Activities = new List<Activity>();
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