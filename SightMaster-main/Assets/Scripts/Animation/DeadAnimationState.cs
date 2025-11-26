using UnityEngine;

public class DeadAnimationState : AnimationState
{
    private const string Dead = "Dead";

    public DeadAnimationState(FSM fsm, Animator animator) : base(fsm, animator,Dead) { }
}
