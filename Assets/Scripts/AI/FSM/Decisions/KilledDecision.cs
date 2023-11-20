namespace AI.FSM.Decisions
{
    public class KilledDecision : Decision
    {
        public bool isDead = true;
        public override bool Decide(BaseStateMachine stm)
        {
            return stm.GetComponent<EnemyState>().isDead == isDead;
        }
    }
}