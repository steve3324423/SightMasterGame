using System.Collections;
using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.Weapon.AimHandler;
using UnityEngine;

public class CameraZoom : BaseCameraZoom
{
    [SerializeField] private float _zoomSpeed = 5f;
    [SerializeField] private Aim _aim;

    private Coroutine _zoomCoroutine;

    protected override void Awake()
    {
        base.Awake();

        if (Application.isMobilePlatform)
        {
            enabled = false;
            return;
        }
    }

    protected override void InitializeZoom()
    {
        if (_aim != null)
        {
            _aim.Aimed += OnAimed;
        }
    }

    protected override void Cleanup()
    {
        if (_aim != null)
        {
            _aim.Aimed -= OnAimed;
        }
        StopZoomCoroutine();
    }

    private IEnumerator ChangeZoom()
    {
        while (enabled)
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

            if (scrollDelta != 0)
            {
                float newFov = _camera.fieldOfView - scrollDelta * _zoomSpeed;
                UpdateCameraFOV(newFov);
            }

            yield return null;
        }
    }

    private void StopZoomCoroutine()
    {
        if (_zoomCoroutine != null)
        {
            StopCoroutine(_zoomCoroutine);
            _zoomCoroutine = null;
        }
    }

    private void OnAimed(bool isAimed)
    {
        if (isAimed)
        {
            StopZoomCoroutine();
            _zoomCoroutine = StartCoroutine(ChangeZoom());
        }
        else
        {
            StopZoomCoroutine();
            UpdateCameraFOV(_minFov);
        }
    }
}