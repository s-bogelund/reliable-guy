using UnityEngine;

namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decision/Distance To Player", fileName = "DistanceToPlayer")]
    public class DistanceToPlayer: Decision
    {
        public float distanceUpperThreshold = float.MaxValue;
        public float distranceLowerThreshold = float.MinValue;
        public string targetTag;
        private GameObject _target;
        
        private void Start()
        {
            _target = GameObject.FindWithTag(targetTag);
        }

        public override bool Decide(BaseStateMachine stm)
        {
            _target = GameObject.FindWithTag(targetTag);
            if (_target == null)
            {
                Debug.LogWarning("Target is null");
                return false;
            }
            
            float distance = Vector3.Distance(stm.transform.position, _target.transform.position);
            
            return distance <= distanceUpperThreshold && distance >= distranceLowerThreshold;
        }
    }
}