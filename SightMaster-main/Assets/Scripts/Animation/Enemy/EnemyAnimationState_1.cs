using UnityEngine;

public class EnemyAnimationState : FSMState
{
    private Animator _animator;
    private string _animationName;

    public EnemyAnimationState(Animator animator,string animationName,FSM fsm) : base(fsm)
    {
        _animationName = animationName;
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.Play(_animationName);
    }
}
