using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation.Enemy
{
    public class IdleEnemyAnimationState : EnemyAnimationState
    {
        private const string Walk = "Walk";

        public IdleEnemyAnimationState(Animator animator, FSM.FSM fsm)
            : base(animator, Walk, fsm) { }
    }
}
