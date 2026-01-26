using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.Weapon;
using SightMaster.Scripts.Weapon.AimHandler;
using System.Collections;
using UnityEngine;
using Zenject;

public class CameraZoom : BaseCameraZoom
{
    [SerializeField] private float _zoomSpeed = 5f;

    private IInputWeapon _inputWeapon;
    private Coroutine _zoomCoroutine;

    [Inject]
    public void Construct(IInputWeapon inputWeapon)
    {
        _inputWeapon = inputWeapon;
        _inputWeapon.Aiming += OnAimed;
    }

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
        if (_inputWeapon != null)
        {
            _inputWeapon.Aiming += OnAimed;
        }
    }

    protected override void Cleanup()
    {
        if (_inputWeapon != null)
        {
            _inputWeapon.Aiming -= OnAimed;
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