using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation.Enemy
{
    public class MoveEnemyAnimationState : EnemyAnimationState
    {
        private const string Move = "Run";

        public MoveEnemyAnimationState(Animator animator, FSM.FSM fsm)
            : base(animator, Move, fsm) { }
    }
}
