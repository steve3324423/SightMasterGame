using SightMaster.Scripts.Weapon;
using SightMaster.Scripts.Weapon.AimHandler;
using UI_Inputs;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.UI
{
    public class JoystickState : MonoBehaviour
    {
        [SerializeField] private UIInputJoystick _movementJoystick;

        private IInputWeapon _inputWeapon;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAimed;
        }

        private void OnDisable()
        {
           _inputWeapon.Aiming -= OnAimed;
        }

        private void OnAimed(bool isAimed)
        {
            if (Application.isMobilePlatform)
                _movementJoystick.gameObject.SetActive(!isAimed);
        }
    }
}
