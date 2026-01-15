using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation.Enemy
{
    public class AttackEnemyAnimationState : EnemyAnimationState
    {
        private const string Attack = "Shoot";

        public AttackEnemyAnimationState(Animator animator, FSM.FSM fsm)
            : base(animator, Attack, fsm) { }
    }
}
