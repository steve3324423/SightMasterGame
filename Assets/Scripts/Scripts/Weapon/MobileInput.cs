using SightMaster.Scripts.UI;
using SightMaster.Scripts.UI.Android;
using System;
using UnityEngine;

namespace SightMaster.Scripts.Weapon
{
    public class MobileInput : IInputWeapon
    {
        private AimButton _aimButtom;
        private ShootButton _shootButton;

        public event Action<bool> Shooting;
        public event Action<bool> Aiming;

        public MobileInput(AimButton aimButtom, ShootButton shootButton)
        {
            _aimButtom = aimButtom;
            _shootButton = shootButton;

            _shootButton.Shooting += OnShooting;
            _aimButtom.Aimed += OnAimed;
        }

        private void OnAimed(bool isAiming)
        {
            Aiming?.Invoke(isAiming);
        }

        private void OnShooting(bool isShooting)
        {
            Shooting?.Invoke(isShooting);
        }
    }
}
