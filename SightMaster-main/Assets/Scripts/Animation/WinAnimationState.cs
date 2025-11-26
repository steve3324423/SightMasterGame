using UnityEngine;

public class WinAnimationState : AnimationState
{
    private const string Win = "Win";

    public WinAnimationState(FSM fsm, Animator animator) : base(fsm, animator, Win) { }
}
