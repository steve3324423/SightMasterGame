using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation
{
    public class IdleAnimationState : AnimationState
    {
        private const string Idle = "Idle";

        public IdleAnimationState(FSM.FSM fsm, Animator animator)
            : base(fsm, animator, Idle) { }
    }
}
