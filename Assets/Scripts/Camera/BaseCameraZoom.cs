using SightMaster.Scripts.CameraHandler;
using System;
using UnityEngine;

namespace SightMaster.Scripts.CameraHandlers
{
    public abstract class BaseCameraZoom : MonoBehaviour, ICameraZoom
    {
        [SerializeField] protected float _minFov = 30f;
        [SerializeField] protected float _maxFov = 8f;

        protected Camera _camera;

        public event Action<float> ZoomChanged;
        public float CurrentZoom => _camera.fieldOfView;

        protected virtual void Awake()
        {
            _camera = GetComponent<Camera>();

            if (Application.isMobilePlatform)
            {
                _camera.fieldOfView = _minFov;
            }
            else
            {
                _camera.fieldOfView = _minFov;
            }
        }

        protected virtual void OnEnable()
        {
            InitializeZoom();
        }

        protected virtual void OnDisable()
        {
            Cleanup();
        }

        protected abstract void InitializeZoom();
        protected abstract void Cleanup();

        protected void UpdateCameraFOV(float newFov)
        {
            float clampedFov = Mathf.Clamp(newFov, _maxFov, _minFov);
            _camera.fieldOfView = clampedFov;
            ZoomChanged?.Invoke(clampedFov);
        }
    }
}