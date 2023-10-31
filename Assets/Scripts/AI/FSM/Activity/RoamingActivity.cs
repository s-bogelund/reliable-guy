using UnityEngine;

namespace AI.FSM.Activity
{
    public interface RoamingActivity
    {
        public void Execute(Rigidbody2D rb2d, Animator animator);
    }
}