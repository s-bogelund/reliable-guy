using UnityEngine;

namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decision/Wait Time", fileName = "WaitTimeDecision")]
    public class WaitTimeDecision: Decision
    {
        public float waitTime = 2.5f;
        float timer = 0f;
        
        public override bool Decide(BaseStateMachine stm)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                timer = 0f;
                return true;
            }

            return false;
        }
    }
}