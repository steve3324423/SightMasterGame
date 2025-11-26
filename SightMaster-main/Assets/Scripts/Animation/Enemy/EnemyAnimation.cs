using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    private DepletionPlayer _depletion;
    private Animator _animator;
    private EnemyAI _enemyAI;
    private FSM _fsm;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _depletion = GetComponent<DepletionPlayer>();
        _animator = GetComponent<Animator>();
        _enemyAI = GetComponent<EnemyAI>();

        _fsm = new FSM();

        _fsm.AddState(new DeadEnemyAnimationState(_animator,_fsm));
        _fsm.AddState(new MoveEnemyAnimationState(_animator,_fsm));
        _fsm.AddState(new IdleEnemyAnimationState(_animator,_fsm));
        _fsm.AddState(new SitEnemyAnimationState(_animator,_fsm));
        _fsm.AddState(new AttackEnemyAnimationState(_animator,_fsm));

        _fsm.SetState<IdleEnemyAnimationState>();
    }

    private void OnEnable()
    {
        if(_enemyAI)
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
        _fsm.SetState<AttackEnemyAnimationState>();
    }

    private void OnReachedShelter()
    {
        _fsm.SetState<SitEnemyAnimationState>();
    }

    private void OnScared()
    {
        _fsm.SetState<MoveEnemyAnimationState>();
    }

    private void OnDead()
    {
        _fsm.SetState<DeadEnemyAnimationState>();
    }
}
