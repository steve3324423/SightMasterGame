using System;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public abstract class InputControl : IInput
    {
        private float _xRotation;
        private float _yRotation;
        private float _zRotation = 0f;
        protected bool IsCanGetValue = true;
        private PlayerHealth _playerHealth;
        private LevelEnder _levelEnder;

        public event Action<float, float> RotationValuesChanged;

        protected InputControl(LevelEnder levelEnder, PlayerHealth playerHealth)
        {
            _levelEnder = levelEnder;
            _playerHealth = playerHealth;

            _levelEnder.Wined += OnWined;
            _playerHealth.Dead += OnDead;
        }

        public abstract float Pitch { get; }
        public abstract float Yaw { get; }

        public virtual Vector3 GetDirection(Transform transformPlayer)
        {
            return Vector3.zero;
        }

        public abstract Quaternion GetCameraRotation();

        public abstract void SetYaw(float yaw);

        protected Quaternion SetCameraRotation(float xValue, float yValue)
        {
            _xRotation = xValue;
            _yRotation = yValue;

            RotationValuesChanged?.Invoke(xValue, yValue);
            return Quaternion.Euler(_xRotation, _yRotation, _zRotation);
        }

        private void OnWined()
        {
            IsCanGetValue = false;
        }

        private void OnDead()
        {
            IsCanGetValue = false;
        }
    }
}