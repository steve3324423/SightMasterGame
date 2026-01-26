using System.Collections;
using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class PanelsHandler : MonoBehaviour
    {
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private LevelEnder _levelEnder;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _pausePanel;

        private WaitForSeconds _waitSeconds;
        private float _timeForCoroutine = 3f;

        private void Awake()
        {
            _waitSeconds = new WaitForSeconds(_timeForCoroutine);
        }

        private void OnEnable()
        {
            _pauseHandler.Paused += OnPaused;
            _playerHealth.Dead += OnDead;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            _pauseHandler.Paused -= OnPaused;
            _playerHealth.Dead -= OnDead;
            _levelEnder.Wined -= OnWined;
        }

        private void OnWined()
        {
            StartCoroutine(EnablePanel(_winPanel));
            SetCursorMode(false);
        }

        private void OnToggled(bool isActivated)
        {
            SetCursorMode(!isActivated);
        }

        private void OnPaused(bool isPaused)
        {
            _pausePanel.SetActive(isPaused);
            SetCursorMode(!isPaused);
        }

        private void OnDead()
        {
            StartCoroutine(EnablePanel(_losePanel));
            SetCursorMode(false);
        }

        private void SetCursorMode(bool isLocked)
        {
            if (Application.isMobilePlatform == false)
                Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private IEnumerator EnablePanel(GameObject panel)
        {
            yield return _waitSeconds;
            panel.SetActive(true);
        }
    }
}
