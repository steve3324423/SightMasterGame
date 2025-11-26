using UnityEngine;

public class IdleEnemyAnimationState : EnemyAnimationState
{
    private const string Walk = "Walk";

    public IdleEnemyAnimationState(Animator animator, FSM fsm) : base(animator, Walk, fsm) { }
}
