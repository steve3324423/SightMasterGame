using SightMaster.Scripts.Weapon.AimHandler;
using UI_Inputs;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class JoystickState : MonoBehaviour
    {
        [SerializeField] private UIInputJoystick _movementJoystick;
        [SerializeField] private Aim _aim;

        private void OnEnable()
        {
            _aim.Aimed += OnAimed;
        }

        private void OnDisable()
        {
            _aim.Aimed -= OnAimed;
        }

        private void OnAimed(bool isAimed)
        {
            if (Application.isMobilePlatform)
                _movementJoystick.gameObject.SetActive(!isAimed);
        }
    }
}
