using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private LevelEnder _levelEnder;

    private IdleAnimationState _idleState;
    private WinAnimationState _winState;
    private MoveAnimationState _moveState;
    private DeadAnimationState _deadState;
    private PlayerHealth _health;
    private Animator _animator;
    private Mover _mover;
    private FSM _fsm;
    private bool _isDead;
    private bool _isWin;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();

        _fsm = new FSM();
        _idleState = new IdleAnimationState(_fsm, _animator);
        _moveState = new MoveAnimationState(_fsm, _animator);
        _deadState = new DeadAnimationState(_fsm, _animator);
        _winState = new WinAnimationState(_fsm, _animator);

        _fsm.AddState(_idleState);
        _fsm.AddState(_moveState);
        _fsm.AddState(_deadState);
        _fsm.AddState(_winState);

        _fsm.SetState<IdleAnimationState>();
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
            _fsm.SetState<MoveAnimationState>();
        else if (_isDead == false && _isWin == false)
            _fsm.SetState<IdleAnimationState>();
    }

    private void OnWined()
    {
        _isWin = true;
        _fsm.SetState<WinAnimationState>();
    }

    private void OnDead()
    {
        _fsm.SetState<DeadAnimationState>();
        _isDead = true;
    }
}
