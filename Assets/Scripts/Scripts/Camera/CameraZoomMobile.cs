using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.UI;
using UnityEngine;

public class CameraZoomMobile : BaseCameraZoom
{
    [SerializeField] private SliderZoom _sliderZoom;

    protected override void Awake()
    {
        base.Awake();

        if (!Application.isMobilePlatform)
        {
            enabled = false;
            return;
        }
    }

    protected override void InitializeZoom()
    {
        if (_sliderZoom != null)
        {
            _sliderZoom.ValueChanged += OnValueChanged;
        }
    }

    protected override void Cleanup()
    {
        if (_sliderZoom != null)
        {
            _sliderZoom.ValueChanged -= OnValueChanged;
        }
    }

    private void OnValueChanged(float value)
    {
        float newFov = Mathf.Lerp(_maxFov, _minFov, value);
        UpdateCameraFOV(newFov);
    }
}