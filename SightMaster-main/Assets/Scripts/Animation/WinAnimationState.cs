using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation
{
    public class WinAnimationState : AnimationState
    {
        private const string Win = "Win";

        public WinAnimationState(FSM.FSM fsm, Animator animator)
            : base(fsm, animator, Win) { }
    }
}
