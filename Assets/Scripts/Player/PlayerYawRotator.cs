using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.UI;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public class PlayerYawRotator : MonoBehaviour
    {
        [SerializeField] private SettingPanelHandler _settingPanelHandler;
        [SerializeField] private Transform _playerRoot;
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private PlayerHealth _playerHealth;

        private bool _isCanRotate = true;
        private IInput _input;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;
        }

        private void OnEnable()
        {
            _settingPanelHandler.Toggled += OnToggled;
            _playerHealth.Dead += OnDead;
            _pauseHandler.Paused += OnPaused;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            _settingPanelHandler.Toggled -= OnToggled;
            _playerHealth.Dead -= OnDead;
            _pauseHandler.Paused -= OnPaused;
            _levelEnder.Wined -= OnWined;
        }

        private void LateUpdate()
        {
            if (_isCanRotate == false || _playerRoot == null || _input == null)
                return;

            float yaw = _input.Yaw;
            Vector3 euler = _playerRoot.eulerAngles;
            euler.y = yaw;
            _playerRoot.rotation = Quaternion.Euler(euler);
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
    }
}