using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.Setting;
using UnityEngine;
using YG;

namespace SightMaster.Scripts.Player
{
    public class DekstopInput : InputControl
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        private const float MinPitch = -30f;
        private const float MaxPitch = 70f;
        private const float SmoothSpeed = 25f;

        private float _differenceValue = .001f;
        private float _pitch = 15f;
        private float _yaw = 0f;
        private Sensitivity _sensitivity;
        private float _targetPitch = 15f;
        private float _targetYaw = 0f;

        public DekstopInput(LevelEnder levelEnder, PlayerHealth playerHealth, Sensitivity sensitivity)
            : base(levelEnder, playerHealth)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _sensitivity = sensitivity;
            _targetPitch = _pitch;
            _targetYaw = _yaw;
        }

        public override float Pitch => _pitch;
        public override float Yaw => _yaw;

        public override Vector3 GetDirection(Transform transformPlayer)
        {
            if (IsCanGetValue)
            {
                float horizontal = Input.GetAxis(Horizontal);
                float vertical = Input.GetAxis(Vertical);

                return transformPlayer.right * horizontal + transformPlayer.forward * vertical;
            }

            return base.GetDirection(transformPlayer);
        }

        public override Quaternion GetCameraRotation()
        {
            if (!IsCanGetValue)
                return SetCameraRotation(_pitch, _yaw);

            float mouseX = Input.GetAxis(MouseX);
            float mouseY = Input.GetAxis(MouseY);

            float sensitivity = YG2.saves.sensitivity * _sensitivity.SensitivityValue;

            _targetYaw += mouseX * sensitivity;
            _targetPitch -= mouseY * sensitivity;
            _targetPitch = Mathf.Clamp(_targetPitch, MinPitch, MaxPitch);

            _yaw = Mathf.Lerp(_yaw, _targetYaw, Time.unscaledDeltaTime * SmoothSpeed);
            _pitch = Mathf.Lerp(_pitch, _targetPitch, Time.unscaledDeltaTime * SmoothSpeed);

            if (Mathf.Abs(_yaw - _targetYaw) < _differenceValue)
                _yaw = _targetYaw;

            if (Mathf.Abs(_pitch - _targetPitch) < _differenceValue)
                _pitch = _targetPitch;

            return SetCameraRotation(_pitch, _yaw);
        }

        public override void SetYaw(float yaw)
        {
            _yaw = yaw;
            _targetYaw = yaw;
            SetCameraRotation(_pitch, _yaw);
        }
    }
}