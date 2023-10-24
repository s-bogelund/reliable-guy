using UnityEngine;

namespace AI.FSM
{
    public class DistanceToPlayer: Decision
    {
        public float distanceThreshold;
        public string targetTag;
        private GameObject _target;
        
        private void Start()
        {
            _target = GameObject.FindWithTag(targetTag);
        }

        public override bool Decide(BaseStateMachine stm)
        {
            if (_target == null)
            {
                Debug.LogWarning("Target is null");
                return false;
            }
            
            float distance = Vector3.Distance(stm.transform.position, _target.transform.position);
            
            return distance <= distanceThreshold;
        }
    }
}