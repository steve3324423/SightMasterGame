using UnityEngine;

public class DeadEnemyAnimationState : EnemyAnimationState
{
    private const string Death = "Death";

    public DeadEnemyAnimationState(Animator animator, FSM fsm) : base(animator, Death, fsm) { }
}
