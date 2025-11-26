using UnityEngine;

public class MoveEnemyAnimationState : EnemyAnimationState
{
    private const string Move = "Run";

    public MoveEnemyAnimationState(Animator animator,FSM fsm) : base(animator,Move,fsm) { }
}
