using System;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.Shop
{
    public class SelectButton : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private BuyButton _buy;

        private int _currentIdWeapon;

        public event Action<int> Selected;

        private void OnEnable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
            _buy.Buyed += OnBuyed;
        }

        private void OnDisable()
        {
            _weaponView.WeaponChanged -= OnWeaponChanged;
            _buy.Buyed -= OnBuyed;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            _currentIdWeapon = weapon.GetId();
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            Select();
        }

        public void Select()
        {
            foreach (int id in YG2.saves.idWeaponBuy)
            {
                if (id == _currentIdWeapon)
                {
                    YG2.saves.idWeaponSelect = _currentIdWeapon;
                    YG2.SaveProgress();
                }
            }

            Selected?.Invoke(_currentIdWeapon);
        }
    }
}
