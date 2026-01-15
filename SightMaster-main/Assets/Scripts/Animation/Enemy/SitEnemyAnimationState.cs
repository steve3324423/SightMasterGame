using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation.Enemy
{
    public class SitEnemyAnimationState : EnemyAnimationState
    {
        private const string Sit = "Sit";

        public SitEnemyAnimationState(Animator animator, FSM.FSM fsm)
            : base(animator, Sit, fsm) { }
    }
}
