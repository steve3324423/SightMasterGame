using System;
using System.Collections;
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.Enemy.EnemyWeapon
{
    [RequireComponent(typeof(WeaponDeadHandler))]
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DepletionPlayer _depletion;
        [SerializeField] private float _timeShoot = 1f;
        [SerializeField] private int _minDamage = 0;
        [SerializeField] private int _damage = 1;

        private bool _isPlayerDisappeared = true;
        private WeaponDeadHandler _weaponDeadHandler;
        private WaitForSeconds _waitForSeconds;
        private VisiblePlayer _hiddenPlace;

        public event Action Shooted;

        private void Awake()
        {
            _hiddenPlace = GetComponent<VisiblePlayer>();
            _weaponDeadHandler = GetComponent<WeaponDeadHandler>();
            _waitForSeconds = new WaitForSeconds(_timeShoot);
        }

        private void OnEnable()
        {
            if (_hiddenPlace != null)
                _hiddenPlace.PlayerDisappeared += OnPlayerDisappeared;

            _playerHealth.Dead += OnDead;
            _weaponDeadHandler.Falled += OnFalled;
            _depletion.Depleted += OnDepleted;
        }

        private void OnDisable()
        {
            if (_hiddenPlace != null)
                _hiddenPlace.PlayerDisappeared -= OnPlayerDisappeared;

            _playerHealth.Dead -= OnDead;
            _weaponDeadHandler.Falled -= OnFalled;
            _depletion.Depleted -= OnDepleted;
        }

        private void OnDepleted()
        {
            StartCoroutine(Shoot());
        }

        private void OnPlayerDisappeared(bool isPlayerDisappeared)
        {
            _isPlayerDisappeared = isPlayerDisappeared;
        }

        private IEnumerator Shoot()
        {
            while (enabled)
            {
                int damage =  UnityEngine.Random.Range(_minDamage, _damage + 1);
                _playerHealth.TakeDamage(_isPlayerDisappeared == false ? 0 : damage);
                Shooted?.Invoke();

                yield return _waitForSeconds;
            }
        }

        private void OnDead()
        {
            StopAllCoroutines();
        }

        private void OnFalled()
        {
            StopAllCoroutines();
            enabled = false;
        }
    }
}
