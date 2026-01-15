using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation.Enemy
{
    public class DeadEnemyAnimationState : EnemyAnimationState
    {
        private const string Death = "Death";

        public DeadEnemyAnimationState(Animator animator, FSM.FSM fsm)
            : base(animator, Death, fsm) { }
    }
}
