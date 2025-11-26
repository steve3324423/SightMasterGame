using System;
using Unity.VisualScripting;
using UnityEngine;

public class SettingPanelHandler : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private PlayerHealth _playerHealth;

    private bool _isTouched;
    private bool _canEnable = true;

    public event Action<bool> Toggled;

    private void OnEnable()
    {
        _pauseHandler.Paused += OnPaused;
        _levelEnder.Wined += OnWined;
        _playerHealth.Dead += OnDead;
    }

    private void OnDisable()
    {
        _pauseHandler.Paused -= OnPaused;
        _levelEnder.Wined -= OnWined;
        _playerHealth.Dead -= OnDead;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            TogglePanel();
    }

    public void Touched()
    {
        TogglePanel();
    }

    private void OnPaused(bool isPaused)
    {
        _canEnable = !isPaused;
    }

    private void OnWined()
    {
        _canEnable = false;
    }

    private void OnDead()
    {
        _canEnable = false;
    }

    private void TogglePanel()
    {
        if(_canEnable)
        {
            _isTouched = !_isTouched;
            _settingPanel.SetActive(_isTouched);
            Toggled?.Invoke(_isTouched);
        }
    }    
}
