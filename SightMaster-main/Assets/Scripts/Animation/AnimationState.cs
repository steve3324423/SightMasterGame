using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation
{
    public class AnimationState : FSMState
    {
        protected Animator _animator;
        protected string _animationName;

        public AnimationState(FSM.FSM fsm, Animator animator, string animationName)
            : base(fsm)
        {
            _animator = animator;
            _animationName = animationName;
        }

        public override void Enter()
        {
            _animator.Play(_animationName);
        }
    }
}