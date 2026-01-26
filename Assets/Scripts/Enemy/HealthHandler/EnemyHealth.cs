using System;
using SightMaster.Scripts.DamageObject;
using UnityEngine;

namespace SightMaster.Scripts.Enemy.HealthHandler
{
    public class EnemyHealth : HealthSystem
    {
        [SerializeField] private float _timeForDead = 1.7f;
        [SerializeField] private HeadEnemy head;

        protected override void Awake()
        {
            base.Awake();
            head = GetComponentInChildren<HeadEnemy>();
        }

        private void OnEnable()
        {
            if (head != null)
                head.Hited += OnHited;
        }

        private void OnDisable()
        {
            if (head != null)
                head.Hited -= OnHited;
        }

        protected override void Die()
        {
            base.Die();
            Destroy(gameObject, _timeForDead);
        }

        private void OnHited(int damage)
        {
            TakeDamage(damage);
        }
    }
}