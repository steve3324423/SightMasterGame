using System;
using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;
using UnityEngine.AI;

namespace SightMaster.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private EnemyWeapon.EnemyWeapon _enemyWeapon;
        [SerializeField] private DepletionPlayer _depletion;
        [SerializeField] private Transform[] _targets;
        [SerializeField] private Transform _shelter;

        private EnemyHealth _enemyHealth;
        private NavMeshAgent _agent;
        private bool _hasReachedShelter = false;
        private float _minDistance = .5f;
        private float _increaseValue = 1.2f;
        private bool _isDepleted;
        private bool _isScared;
        private int _index = 0;

        public event Action ReachedShelter;

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            _enemyWeapon.Shooted += OnShooted;
            _depletion.Depleted += OnDepleted;
            _depletion.Scared += OnScrared;
            _enemyHealth.Dead += OnDead;
        }

        private void OnDisable()
        {
            _enemyWeapon.Shooted -= OnShooted;
            _depletion.Depleted -= OnDepleted;
            _depletion.Scared -= OnScrared;
            _enemyHealth.Dead -= OnDead;
        }

        private void Update()
        {
            if (_isDepleted == false && _isScared == false)
                SetTargets();

            if (_isScared && _agent.remainingDistance <= _minDistance && _agent.pathPending == false && _hasReachedShelter == false)
            {
                ReachedShelter?.Invoke();
                _hasReachedShelter = true;
            }
        }

        private void SetTargets()
        {
            _agent.destination = _targets[_index].position;
            SetRotation();

            if (_agent.remainingDistance <= _minDistance && _agent.pathPending == false)
                _index = (_index + 1) % _targets.Length;
        }

        private void SetRotation()
        {
            Vector3 direction = _targets[_index].position - transform.position;
            direction.y = transform.position.y;

            transform.rotation = Quaternion.LookRotation(_targets[_index].position - transform.position);
        }

        private void OnScrared()
        {
            _isScared = true;
            _agent.speed *= _increaseValue;
            _agent.destination = _shelter.position;
        }

        private void OnDepleted()
        {
            _isDepleted = true;
            _isScared = false;
            _agent.isStopped = true;
        }

        private void OnDead()
        {
            _agent.isStopped = true;
            enabled = false;
        }

        private void OnShooted()
        {
            enabled = false;
        }
    }
}
