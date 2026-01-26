using System;
using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    public class WaveDestroyHandler : MonoBehaviour
    {
        private EnemyHealth[] _enemyHealths;
        private int _enemiesAlive;

        public event Action Destroyed;

        private void Awake()
        {
            _enemyHealths = GetComponentsInChildren<EnemyHealth>();
            _enemiesAlive = _enemyHealths.Length;
        }

        private void OnEnable()
        {
            foreach (EnemyHealth enemyHealth in _enemyHealths)
                enemyHealth.Dead += OnDeadEnemy;
        }

        private void OnDisable()
        {
            foreach (EnemyHealth enemyHealth in _enemyHealths)
                enemyHealth.Dead -= OnDeadEnemy;
        }

        private void OnDeadEnemy()
        {
            _enemiesAlive--;

            if (_enemiesAlive <= 0)
                Destroyed?.Invoke();
        }
    }
}
