using SightMaster.Scripts.FSM;
using SightMaster.Scripts.LevelHandler;  
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.Animation
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private LevelEnder _levelEnder;

        private AnimationState _idleState;
        private AnimationState _winState;
        private AnimationState _moveState;
        private AnimationState _deadState;
        private PlayerHealth _health;
        private Animator _animator;
        private Mover _mover;
        private StateMachine _stateMachine;
        private bool _isDead;
        private bool _isWin;

        private void Awake()
        {
            _health = GetComponent<PlayerHealth>();
            _animator = GetComponent<Animator>();
            _mover = GetComponent<Mover>();

            _stateMachine = new StateMachine();
            _idleState = new AnimationState(_stateMachine, _animator, PlayerAnimationNames.Idle);
            _moveState = new AnimationState(_stateMachine, _animator, PlayerAnimationNames.Move);
            _deadState = new AnimationState(_stateMachine, _animator, PlayerAnimationNames.Dead);
            _winState = new AnimationState(_stateMachine, _animator, PlayerAnimationNames.Win);

            _stateMachine.AddState(PlayerAnimationNames.Idle, _idleState);
            _stateMachine.AddState(PlayerAnimationNames.Move, _moveState);
            _stateMachine.AddState(PlayerAnimationNames.Dead, _deadState);
            _stateMachine.AddState(PlayerAnimationNames.Win, _winState);

            _stateMachine.SetState(PlayerAnimationNames.Idle);
        }

        private void OnEnable()
        {
            _levelEnder.Wined += OnWined;
            _mover.Moved += OnMoved;
            _health.Dead += OnDead;
        }

        private void OnDisable()
        {
            _levelEnder.Wined -= OnWined;
            _mover.Moved -= OnMoved;
            _health.Dead -= OnDead;
        }

        private void OnMoved(bool isMove)
        {
            if (isMove && _isDead == false)
                _stateMachine.SetState(PlayerAnimationNames.Move);
            else if (_isDead == false && _isWin == false)
                _stateMachine.SetState(PlayerAnimationNames.Idle);
        }

        private void OnWined()
        {
            _isWin = true;
            _stateMachine.SetState(PlayerAnimationNames.Win);
        }

        private void OnDead()
        {
            _stateMachine.SetState(PlayerAnimationNames.Dead);
            _isDead = true;
        }
    }
}