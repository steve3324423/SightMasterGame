using UnityEngine;
using YG;

public class CameraRotationMobile : MonoBehaviour
{
    [SerializeField] private AimButton _aimButton;
    [SerializeField] private UITouchControl[] _touchControls;
    [SerializeField] private float _touchAreaFraction = 0.5f;
    [SerializeField] private float _deadZone = 0.01f;
    [SerializeField] private float _smoothTime = 0.1f;

    private float _horizontalSensitivity = 2f;
    private float _currentRotationXVelocity;
    private float _currentRotationYVelocity;
    private float _verticalSensitivity = 2f;
    private float _verticalAngle = 45;
    private bool _isDragging;
    private bool _isTouched;
    private bool _isAimed;
    private Vector2 _previousTouchPosition;

    public float RotationX { private set; get; }
    public float RotationY { private set; get; }

    private void OnEnable()
    {
        foreach (UITouchControl touchControl in _touchControls)
            touchControl.Touched += OnTouched;

        _aimButton.Aimed += OnAimed;
        GetSavesData();
    }

    private void OnDisable()
    {
        foreach (UITouchControl touchControl in _touchControls)
            touchControl.Touched -= OnTouched;

        _aimButton.Aimed -= OnAimed;
    }

    private void OnTouched(bool isTouched)
    {
        _isTouched = isTouched;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isDragging = true;
                    _previousTouchPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    if (_isDragging && _isTouched == false)
                    {
                        Vector2 touchDelta = touch.position - _previousTouchPosition;

                        if (Mathf.Abs(touchDelta.x) < _deadZone)
                            touchDelta.x = 0;

                        if (Mathf.Abs(touchDelta.y) < _deadZone)
                            touchDelta.y = 0;


                        float targetRotationY = RotationY + touchDelta.x * _horizontalSensitivity * Time.deltaTime;
                        float targetRotationX = RotationX - touchDelta.y * _verticalSensitivity * Time.deltaTime;

                        RotationX = Mathf.SmoothDamp(RotationX, targetRotationX, ref _currentRotationXVelocity, _smoothTime);
                        RotationY = Mathf.SmoothDamp(RotationY, targetRotationY, ref _currentRotationYVelocity, _smoothTime);


                        RotationX = Mathf.Clamp(RotationX, -_verticalAngle, _verticalAngle);
                        RotationY = Mathf.Clamp(RotationY, -_verticalAngle, _verticalAngle);

                        _previousTouchPosition = touch.position;
                    }
                    break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        _isDragging = false;
                        break;
            }
        }
    }

    private void OnAimed(bool isAimed)
    {
        _isAimed = isAimed;
    }

    private void GetSavesData()
    {
        _horizontalSensitivity = YG2.saves.sensitivityMobile;
        _verticalSensitivity = YG2.saves.sensitivityMobile;
    }
}