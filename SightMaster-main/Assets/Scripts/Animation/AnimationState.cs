using UnityEngine;

public class AnimationState : FSMState
{
    protected Animator _animator;
    protected string _animationName;

    public AnimationState(FSM fsm,Animator animator, string animationName)  : base(fsm)
    {
        _animator = animator;
        _animationName = animationName;
    }

    public override void Enter()
    {
        _animator.Play(_animationName);
    }
}