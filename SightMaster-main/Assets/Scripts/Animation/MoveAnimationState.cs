using UnityEngine;

public class MoveAnimationState : AnimationState
{
    private const string Move = "Move";

    public MoveAnimationState(FSM fsm, Animator animator) : base(fsm, animator, Move) { }
}
