using SightMaster.Scripts.Setting;
using SightMaster.Scripts.UI;
using SightMaster.Scripts.UI.Android;
using SightMaster.Scripts.Weapon;
using SightMaster.Scripts.Weapon.AimHandler;
using UnityEngine;
using YG;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public class CameraRotationMobile : MonoBehaviour
    {
        [SerializeField] private Sensitivity _sensitivity;
        [SerializeField] private AimButton _aimButton;
        [SerializeField] private UITouchControl[] _touchControls;
        [SerializeField] private UIBlocker _uiBlocker;
        [SerializeField] private float _touchAreaFraction = 0.5f;
        [SerializeField] private float _deadZone = 0.01f;
        [SerializeField] private float _mobileValue = 1.5f;
        [SerializeField] private float _smoothTime = 0.1f;

        private IInputWeapon _inputWeapon;
        private float _currentRotationXVelocity;
        private float _currentRotationYVelocity;
        private float _verticalAngle = 45;
        private bool _isDragging;
        private bool _isAnyUIControlTouched;
        private Vector2 _previousTouchPosition;

        public float RotationX { get; private set; }
        public float RotationY { get; private set; }

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAimed;
        }


        private void OnEnable()
        {
            foreach (UITouchControl touchControl in _touchControls)
                touchControl.Touched += OnTouched;
        }

        private void OnDisable()
        {
            foreach (UITouchControl touchControl in _touchControls)
                touchControl.Touched -= OnTouched;

            _inputWeapon.Aiming -= OnAimed;
        }

        private void OnTouched(bool isTouched)
        {
            _isAnyUIControlTouched = isTouched;
        }

        private void Update()
        {
            if (_uiBlocker.IsUIBeingTouched)
            {
                _isDragging = false;
                return;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float screenStartOfTouchAreaX = Screen.width * _touchAreaFraction;
                bool isUIBlockingCamera = _isAnyUIControlTouched;

                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        if (touch.position.x >= screenStartOfTouchAreaX)
                        {
                            _isDragging = true;
                            _previousTouchPosition = touch.position;
                        }
                        else
                        {
                            _isDragging = false;
                        }

                        break;

                    case TouchPhase.Moved:

                        if (_isDragging)
                        {
                            Vector2 touchDelta = touch.position - _previousTouchPosition;

                            if (Mathf.Abs(touchDelta.x) < _deadZone)
                                touchDelta.x = 0;

                            if (Mathf.Abs(touchDelta.y) < _deadZone)
                                touchDelta.y = 0;

                            float horizontalSensitivity = YG2.saves.sensitivity * _mobileValue * _sensitivity.SensitivityValue;
                            float verticalSensitivity = YG2.saves.sensitivity * _mobileValue * _sensitivity.SensitivityValue;
                            float targetRotationY = RotationY + touchDelta.x * horizontalSensitivity * Time.deltaTime;
                            float targetRotationX = RotationX - touchDelta.y * verticalSensitivity * Time.deltaTime;

                            RotationX = Mathf.SmoothDamp(RotationX, targetRotationX, ref _currentRotationXVelocity, _smoothTime);
                            RotationY = Mathf.SmoothDamp(RotationY, targetRotationY, ref _currentRotationYVelocity, _smoothTime);
                            RotationX = Mathf.Clamp(RotationX, -_verticalAngle, _verticalAngle);

                            _previousTouchPosition = touch.position;
                        }

                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        _isDragging = false;
                        break;
                }
            }
            else
            {
                _isDragging = false;
            }
        }

        private void OnAimed(bool isAimed)
        {
            _touchAreaFraction = isAimed ? 0f : 0.5f;
        }
    }
}