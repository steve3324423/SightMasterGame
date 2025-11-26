using UnityEngine;

public class IdleAnimationState : AnimationState
{
    private const string Idle = "Idle";

    public IdleAnimationState(FSM fsm, Animator animator) : base(fsm, animator, Idle) { }
}
