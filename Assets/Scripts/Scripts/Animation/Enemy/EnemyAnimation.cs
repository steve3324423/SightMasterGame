using SightMaster.Scripts.Enemy;
using SightMaster.Scripts.Enemy.HealthHandler;
using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.Animation.Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    [RequireComponent(typeof(DepletionPlayer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(EnemyAI))]
    public class EnemyAnimation : MonoBehaviour
    {
        private EnemyHealth _enemyHealth;
        private DepletionPlayer _depletion;
        private Animator _animator;
        private EnemyAI _enemyAI;
        private StateMachine _stateMachine;
        private AnimationState _idleState;
        private AnimationState _moveState;
        private AnimationState _attackState;
        private AnimationState _sitState;
        private AnimationState _deathState;

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _depletion = GetComponent<DepletionPlayer>();
            _animator = GetComponent<Animator>();
            _enemyAI = GetComponent<EnemyAI>();

            _stateMachine = new StateMachine();

            _idleState = new AnimationState(_stateMachine, _animator, EnemyAnimationNames.Idle);
            _moveState = new AnimationState(_stateMachine, _animator, EnemyAnimationNames.Run);
            _attackState = new AnimationState(_stateMachine, _animator, EnemyAnimationNames.Shoot);
            _sitState = new AnimationState(_stateMachine, _animator, EnemyAnimationNames.Sit);
            _deathState = new AnimationState(_stateMachine, _animator, EnemyAnimationNames.Death);

            _stateMachine.AddState(EnemyAnimationNames.Idle, _idleState);
            _stateMachine.AddState(EnemyAnimationNames.Run, _moveState);
            _stateMachine.AddState(EnemyAnimationNames.Shoot, _attackState);
            _stateMachine.AddState(EnemyAnimationNames.Sit, _sitState);
            _stateMachine.AddState(EnemyAnimationNames.Death, _deathState);

            _stateMachine.SetState(EnemyAnimationNames.Idle);
        }

        private void OnEnable()
        {
            if (_enemyAI)
            {
                _enemyAI.ReachedShelter += OnReachedShelter;
                _depletion.Scared += OnScared;
            }

            _depletion.Depleted += OnDepleted;
            _enemyHealth.Dead += OnDead;
        }

        private void OnDisable()
        {
            if (_enemyAI)
            {
                _enemyAI.ReachedShelter -= OnReachedShelter;
                _depletion.Scared -= OnScared;
            }

            _depletion.Depleted -= OnDepleted;
            _enemyHealth.Dead -= OnDead;
        }

        private void OnDepleted()
        {
            _stateMachine.SetState(EnemyAnimationNames.Shoot);
        }

        private void OnReachedShelter()
        {
            _stateMachine.SetState(EnemyAnimationNames.Sit);
        }

        private void OnScared()
        {
            _stateMachine.SetState(EnemyAnimationNames.Run);
        }

        private void OnDead()
        { 
            _stateMachine.SetState(EnemyAnimationNames.Death);
        }
    }
}
