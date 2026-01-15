using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation
{
    public class DeadAnimationState : AnimationState
    {
        private const string Dead = "Dead";

        public DeadAnimationState(FSM.FSM fsm, Animator animator)
            : base(fsm, animator, Dead) { }
    }
}
