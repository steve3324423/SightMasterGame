using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation
{
    public class MoveAnimationState : AnimationState
    {
        private const string Move = "Move";

        public MoveAnimationState(FSM.FSM fsm, Animator animator)
            : base(fsm, animator, Move) { }
    }
}
