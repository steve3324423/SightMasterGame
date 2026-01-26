using System;
using System.Collections;
using SightMaster.Scripts.Weapon.AimHandler;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Weapon
{
    public class AmmoHandler : MonoBehaviour
    {
        [SerializeField] private int _magazineSize = 30;

        private bool _isShooting;
        private bool _isCanShoot = true;
        private IInputWeapon _inputWeapon;
        private int _currentAmmo;
        private int _maxAmmo = 120;
        private int _ammoInReserve;
        private bool _isAimed;

        public event Action<int, int> BulletChanged;
        public event Action Shooted;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAimed;
            _inputWeapon.Shooting += OnShooting;
        }

        private void Awake()
        {
            _currentAmmo = _magazineSize;
            _ammoInReserve = _maxAmmo - _magazineSize;

            BulletChanged?.Invoke(_currentAmmo, _ammoInReserve);
        }

        private void OnDisable()
        {
            _inputWeapon.Shooting -= OnShooting;
            _inputWeapon.Aiming -= OnAimed;
        }

        private void OnShooting(bool isShooting)
        {
            _isShooting = isShooting;
        }

        private void Update()
        {
            if (_isAimed && _isCanShoot && _isShooting)
                Shoot();
        }

        private void Shoot()
        {
            _currentAmmo--;
            BulletChanged?.Invoke(_currentAmmo, _ammoInReserve);
            Shooted?.Invoke();

            if (_currentAmmo == 0 && _ammoInReserve > 0)
                StartCoroutine(Reload());
            else
                StartCoroutine(SetCanShoot());
        }

        private IEnumerator Reload()
        {
            float timeReload = 2f;
            _isCanShoot = false;

            while (timeReload > 0)
            {
                timeReload -= Time.deltaTime;
                yield return null;
            }

            int ammoToReload = Mathf.Min(_magazineSize - _currentAmmo, _ammoInReserve);
            _currentAmmo += ammoToReload;
            _ammoInReserve -= ammoToReload;

            BulletChanged?.Invoke(_currentAmmo, _ammoInReserve);
            _isCanShoot = true;
        }

        private IEnumerator SetCanShoot()
        {
            float time = 1f;
            _isCanShoot = false;

            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }

            _isCanShoot = true;
        }

        private void OnAimed(bool isAimed)
        {
            _isAimed = isAimed;
        }
    }
}
