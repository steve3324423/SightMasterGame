using System;
using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    public class DeadEnemyCount : MonoBehaviour
    {
        [SerializeField] private EnemyHealth[] _enemies;

        public event Action<int> Deaded;

        public int Count { get; private set; } = 0;

        private void OnEnable()
        {
            foreach (EnemyHealth enemy in _enemies)
                enemy.Dead += OnDead;
        }

        private void OnDestroy()
        {
            foreach (EnemyHealth enemy in _enemies)
                enemy.Dead -= OnDead;
        }

        private void OnDead()
        {
            Count++;
            Deaded?.Invoke(Count);
        }
    }
}