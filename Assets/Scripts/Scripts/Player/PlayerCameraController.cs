using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.UI;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _cameraTransform;

        [Header("Third Person Settings")]
        [SerializeField] private float _thirdPersonDistance = 3f;
        [SerializeField] private float _cameraCollisionRadius = 0.2f;
        [SerializeField] private LayerMask _cameraCollisionMask;

        [Header("First Person Settings")]
        [SerializeField] private Vector3 _firstPersonOffset = new Vector3(0f, 1.7f, 0f);

        [Header("Mode")]
        [SerializeField] private bool _isFirstPerson = false;

        [SerializeField] private SettingPanelHandler _settingPanelHandler;
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private PlayerHealth _playerHealth;

        private CameraFollowBullet _cameraFollowBullet;
        private bool _isCanRotate = true;
        private IInput _desktopInput;

        [Inject]
        public void Construct(IInput input)
        {
            _desktopInput = input;
        }

        private void Awake()
        {
            _cameraFollowBullet = GetComponent<CameraFollowBullet>();
        }

        private void OnEnable()
        {
            _cameraFollowBullet.Followed += OnFollowed;
            _settingPanelHandler.Toggled += OnToggled;
            _pauseHandler.Paused += OnPaused;
            _playerHealth.Dead += OnDead;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            _cameraFollowBullet.Followed -= OnFollowed;
            _settingPanelHandler.Toggled -= OnToggled;
            _pauseHandler.Paused -= OnPaused;
            _playerHealth.Dead -= OnDead;
            _levelEnder.Wined -= OnWined;
        }

        private void LateUpdate()
        {
            if (_player == null || _cameraTransform == null || _desktopInput == null)
                return;

            Quaternion cameraRotation = _desktopInput.GetCameraRotation();

            if (_isFirstPerson && _isCanRotate)
                UpdateFirstPerson(cameraRotation);
            else if (_isCanRotate)
                UpdateThirdPerson(cameraRotation);
        }

        private void UpdateFirstPerson(Quaternion cameraRotation)
        {
            _cameraTransform.rotation = cameraRotation;
            Vector3 targetPos = _player.position + _player.TransformVector(_firstPersonOffset);
            _cameraTransform.position = targetPos;
        }

        private void UpdateThirdPerson(Quaternion cameraRotation)
        {
            _cameraTransform.rotation = cameraRotation;

            Vector3 pivot = _player.position + _player.TransformVector(_firstPersonOffset);
            Vector3 desiredCameraPos = pivot - _cameraTransform.forward * _thirdPersonDistance;
            RaycastHit hit;

            if (Physics.SphereCast(
                pivot,
                _cameraCollisionRadius,
                (desiredCameraPos - pivot).normalized,
                out hit,
                _thirdPersonDistance,
                _cameraCollisionMask,
                QueryTriggerInteraction.Ignore))
            {
                float distance = hit.distance;
                desiredCameraPos = pivot + (desiredCameraPos - pivot).normalized * (distance - 0.05f);
            }

            _cameraTransform.position = desiredCameraPos;
        }

        private void OnFollowed(bool isFollwed)
        {
            _isCanRotate = !isFollwed;
        }

        private void OnToggled(bool isToggled)
        {
            _isCanRotate = !isToggled;
        }

        private void OnWined()
        {
            _isCanRotate = false;
        }

        private void OnPaused(bool isPaused)
        {
            _isCanRotate = !isPaused;
        }

        private void OnDead()
        {
            _isCanRotate = false;
        }

        public void SetFirstPerson(bool value)
        {
            _isFirstPerson = value;
            float currentYaw = _player.eulerAngles.y;
            _desktopInput.SetYaw(currentYaw);
        }

        public void ToggleView()
        {
            SetFirstPerson(!_isFirstPerson);
        }
    }
}