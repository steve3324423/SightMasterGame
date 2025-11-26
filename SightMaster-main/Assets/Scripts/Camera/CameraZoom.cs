using UnityEngine;
using System.Collections;

public class CameraZoomPC : MonoBehaviour
{
    [SerializeField] private float _zoomSpeed = 5f;
    [SerializeField] private float _minFov = 30f;
    [SerializeField] private float _aimedFov = 8f;
    [SerializeField] private Aim _aim;

    private Coroutine _zoomCoroutine;
    private Camera _camera;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            enabled = false;

        _camera = GetComponent<Camera>();
        _camera.fieldOfView = _minFov;
    }

    private void OnEnable()
    {
        _aim.Aimed += OnAimed;
    }

    private void OnDisable()
    {
        _aim.Aimed -= OnAimed;

        if (_zoomCoroutine != null)
        {
            StopCoroutine(_zoomCoroutine);
            _zoomCoroutine = null;
        }
    }

    private IEnumerator ChangeZoom()
    {
        while (enabled)
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

            if (scrollDelta != 0)
            {
                float newFov = _camera.fieldOfView - scrollDelta * _zoomSpeed;
                newFov = Mathf.Clamp(newFov, _aimedFov, _minFov);
                _camera.fieldOfView = newFov;
            }
            yield return null;
        }
    }

    private void OnAimed(bool isAimed)
    {
        if (isAimed)
        {
            if (_zoomCoroutine != null)
            {
                StopCoroutine(_zoomCoroutine);
            }
            _zoomCoroutine = StartCoroutine(ChangeZoom());
        }
        else
        {
            if (_zoomCoroutine != null)
            {
                StopCoroutine(_zoomCoroutine);
                _zoomCoroutine = null;
            }
            _camera.fieldOfView = _minFov;
        }
    }
}