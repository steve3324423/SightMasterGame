using System;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.Shop
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private WeaponToBuy[] _weapons;
        [SerializeField] private WeaponChange[] _weaponsIndex;

        private WeaponToBuy _currentWeapon;

        public event Action<WeaponToBuy> WeaponChanged;

        private void Start()
        {
            GetSavesData();
        }

        private void OnEnable()
        {
            foreach (WeaponChange weaponIndex in _weaponsIndex)
                weaponIndex.IndexChanged += OnIndexChanged;
        }

        private void OnDisable()
        {
            foreach (WeaponChange weaponIndex in _weaponsIndex)
                weaponIndex.IndexChanged -= OnIndexChanged;
        }

        private void OnIndexChanged(int index)
        {
            if (_currentWeapon != null)
                _currentWeapon.gameObject.SetActive(false);

            _currentWeapon = _weapons[index];
            _currentWeapon.gameObject.SetActive(true);
            WeaponChanged?.Invoke(_currentWeapon);
        }

        private void GetSavesData()
        {
            int index = YG2.saves.idWeaponSelect - 1;
            OnIndexChanged(index);
        }
    }
}
