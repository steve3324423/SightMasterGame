using System;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.Shop
{
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaaponView;

        private WeaponToBuy _currentWeapon;

        public event Action<WeaponToBuy> Buyed;

        public void Buy()
        {
            YG2.saves.money -= _currentWeapon.GetPrice();
            YG2.saves.idWeaponBuy.Add(_currentWeapon.GetId());
            YG2.saves.idWeaponSelect = _currentWeapon.GetId();

            YG2.SaveProgress();
            Buyed?.Invoke(_currentWeapon);
        }

        private void OnEnable()
        {
            _weaaponView.WeaponChanged += OnWeaponChanged;
        }

        private void OnDisable()
        {
            _weaaponView.WeaponChanged -= OnWeaponChanged;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            _currentWeapon = weapon;
        }
    }
}
