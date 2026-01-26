using SightMaster.Scripts.LevelHandler;
using UI_InputSystem.Base;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class MobileWeaponInput : InputControl
    {
        private CameraRotationMobile _cameraRotation;

        public MobileWeaponInput(LevelEnder levelEnder, PlayerHealth playerHealth, CameraRotationMobile cameraRotation)
            : base(levelEnder, playerHealth)
        {
            _cameraRotation = cameraRotation;
        }

        public override float Pitch => _cameraRotation.RotationX;
        public override float Yaw => _cameraRotation.RotationY;

        public override Vector3 GetDirection(Transform transformPlayer)
        {
            if (IsCanGetValue)
                return SetMove(transformPlayer, UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.Movement), UIInputSystem.ME.GetAxisVertical(JoyStickAction.Movement));

            return base.GetDirection(transformPlayer);
        }

        public override Quaternion GetCameraRotation()
        {
            return SetCameraRotation(_cameraRotation.RotationX, _cameraRotation.RotationY);
        }

        private Vector3 SetMove(Transform transformPlayer, float horizontal, float vertical)
        {
            return transformPlayer.right * horizontal + transformPlayer.forward * vertical;
        }

        public override void SetYaw(float yaw)
        {
            SetCameraRotation(_cameraRotation.RotationX, _cameraRotation.RotationY);
        }
    }
}
