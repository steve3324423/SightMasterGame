using UnityEngine;

public class AttackEnemyAnimationState : EnemyAnimationState
{
    private const string Attack = "Shoot";

    public AttackEnemyAnimationState(Animator animator,FSM fsm) : base(animator,Attack,fsm) {}
}
