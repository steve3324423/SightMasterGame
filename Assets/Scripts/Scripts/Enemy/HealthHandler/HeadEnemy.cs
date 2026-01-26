using System;
using System.Collections;
using SightMaster.Scripts.DamageObject;
using UnityEngine;

namespace SightMaster.Scripts.Enemy.HealthHandler
{
    public class HeadEnemy : MonoBehaviour, IDamageObject
    {
        [SerializeField] private float _timeForCoroutine = .5f;

        private WaitForSeconds _waitSeconds;
        private int _damage = 100;

        public event Action<int> Hited;

        private void Awake()
        {
            _waitSeconds = new WaitForSeconds(_timeForCoroutine);
        }

        public void TakeDamage(int damage)
        {
            StartCoroutine(SendDamage());
        }

        private IEnumerator SendDamage()
        {
            yield return _waitSeconds;
            Hited?.Invoke(_damage);
        }
    }
}
