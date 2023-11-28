using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM.Activity
{
    public class PatrolPoints: MonoBehaviour
    {
        public List<Vector3> points;
        private Vector3 _targetPoint;
        private int _index;
        
        public void Start()
        {
            _index = 0;
            _targetPoint = points[_index];
        }

        public bool HasReachedTargetPoint()
        {
            return Vector3.Distance(transform.position, _targetPoint) <= 0.01f;
        }

        public void SetNextPatrolPoint()
        {
            _index = (_index + 1) % points.Count;
            _targetPoint = points[_index];
        }
        
        public Vector3 GetTargetPointDirection()
        {
            return (_targetPoint - transform.position).normalized;
        }
    }
}