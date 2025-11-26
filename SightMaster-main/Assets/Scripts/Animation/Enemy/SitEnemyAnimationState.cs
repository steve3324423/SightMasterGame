using UnityEngine;

public class SitEnemyAnimationState : EnemyAnimationState
{
    private const string Sit = "Sit";

    public SitEnemyAnimationState(Animator animator, FSM fsm) : base(animator,Sit,fsm) { }
}
