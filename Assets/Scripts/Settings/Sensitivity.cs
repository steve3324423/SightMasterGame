using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.CameraHandler;
using UnityEngine;

public class Sensitivity : MonoBehaviour
{
    private const float MinZoomValue = 8f;
    private const float MaxZoomValue = 30f;

    private ICameraZoom _cameraZoom;
    private int _defaultPCValue = 1;
    private float _mobileMultiplier = 15f;

    public float SensitivityValue { get; private set; }

    private void Awake()
    {
        _cameraZoom = GetComponent<BaseCameraZoom>();

        if (_cameraZoom != null)
            SensitivityValue = CalculateZoomDependentSensitivity(_cameraZoom.CurrentZoom, Application.isMobilePlatform ? _mobileMultiplier : _defaultPCValue);
    }

    private void OnEnable()
    {
        if (_cameraZoom != null)
        {
            _cameraZoom.ZoomChanged += OnZoomChanged;
        }
    }

    private void OnDisable()
    {
        if (_cameraZoom != null)
        {
            _cameraZoom.ZoomChanged -= OnZoomChanged;
        }
    }

    private void OnZoomChanged(float zoomValue)
    {
        SensitivityValue = CalculateZoomDependentSensitivity(
            zoomValue,
            Application.isMobilePlatform ? _mobileMultiplier : _defaultPCValue
        );
    }

    private float CalculateZoomDependentSensitivity(float currentZoomValue, float platformBaseMultiplier)
    {
        float clampedZoomValue = Mathf.Clamp(currentZoomValue, MinZoomValue, MaxZoomValue);
        float zoomMultiplier = clampedZoomValue / MaxZoomValue;

        return zoomMultiplier * platformBaseMultiplier;
    }
}