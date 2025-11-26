using System.Collections;
using UnityEngine;

public class PanelsHandler : MonoBehaviour
{
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private SettingPanelHandler _settingHandlerPanel;

    private WaitForSeconds _waitSeconds;
    private float _timeForCoroutine = 3f;

    private void Awake()
    {
        _waitSeconds = new WaitForSeconds(_timeForCoroutine);
    }

    private void OnEnable()
    {
        _settingHandlerPanel.Toggled += OnToggled;
        _pauseHandler.Paused += OnPaused;
        _playerHealth.Dead += OnDead;
        _levelEnder.Wined += OnWined;
    }

    private void OnDisable()
    {
        _settingHandlerPanel.Toggled -= OnToggled;
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
        if(Application.isMobilePlatform == false)
            Cursor.lockState = isLocked ? CursorLockMode.Locked :CursorLockMode.None;
    }

    private IEnumerator EnablePanel(GameObject panel)
    {
        yield return _waitSeconds;
        panel.SetActive(true);
    }
}
