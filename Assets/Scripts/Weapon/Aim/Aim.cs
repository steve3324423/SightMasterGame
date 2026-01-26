using System;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Weapon.AimHandler
{
    public class Aim : MonoBehaviour
    {
        private IInputWeapon _inputWeapon;

        public event Action<bool> Aimed;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAiming;
        }

        private void OnAiming(bool isAiming)
        {
            Aimed?.Invoke(isAiming);
        }
    }
}
