using UnityEngine;
using YG;

public class Sensitivity : MonoBehaviour
{
    private const float MinZoomValue = 8f;
    private const float MaxZoomValue = 30f;

    private CameraZoomMobile _zoomMobile;
    private CameraZoomPC _zoomPC;
    private int _defaultValue = 1;
    private float _mobileValue = 15f;

    public float SensitivityValue { get; private set; }

    private void Awake()
    {
        _zoomMobile = GetComponent<CameraZoomMobile>();
        _zoomPC = GetComponent<CameraZoomPC>();

        float initialFOV = MaxZoomValue;
        SensitivityValue = CalculateZoomDependentSensitivity(initialFOV, Application.isMobilePlatform ? _mobileValue : _defaultValue);
    }

    private void OnEnable()
    {
        if (_zoomMobile != null)
            _zoomMobile.ZoomChanged += OnZoomChanged;

        if (Application.isMobilePlatform == false)
            _zoomPC.ZoomChanged += OnZoomChanged;
    }

    private void OnDisable()
    {
        if (_zoomMobile != null)
            _zoomMobile.ZoomChanged -= OnZoomChanged;

        if (Application.isMobilePlatform == false)
            _zoomPC.ZoomChanged -= OnZoomChanged;
    }

    private void OnZoomChanged(float zoomValue)
    {
        SensitivityValue = CalculateZoomDependentSensitivity(zoomValue, Application.isMobilePlatform ? _mobileValue : _defaultValue);
    }

    private float CalculateZoomDependentSensitivity(float currentZoomValue, float platformBaseMultiplier)
    {
        float clampedZoomValue = Mathf.Clamp(currentZoomValue, MinZoomValue, MaxZoomValue);
        float zoomMultiplier = clampedZoomValue / MaxZoomValue;

        float finalSensitivityMultiplier = zoomMultiplier * platformBaseMultiplier;

        return finalSensitivityMultiplier;
    }
}