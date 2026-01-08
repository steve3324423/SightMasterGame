using System;
using UnityEngine;

public class CameraZoomMobile : MonoBehaviour
{
    [SerializeField] private SliderZoom _sliderZoom;

    private Camera _camera;

    public event Action<float> ZoomChanged; 

    private void Awake()
    {
        if(Application.isMobilePlatform == false)
            enabled = false;

        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        _sliderZoom.ValueChanged += OnValueChanged;
    }

    private void OnDestroy()
    {
        _sliderZoom.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        _camera.fieldOfView = value;
        ZoomChanged?.Invoke(value);
    }
}
