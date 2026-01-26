using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.Player;
using SightMaster.Scripts.UI;
using UnityEngine;

public class UIElementsHandler : MonoBehaviour
{
    [SerializeField] private CameraFollowBullet _cameraFollowBullet;
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private SettingPanelHandler _settingHandler;
    [SerializeField] private LevelEnder _levelEnder;

    private void OnEnable()
    {
        _cameraFollowBullet.Followed += OnFollowed;
        _settingHandler.Toggled += OnToggled;
        _pauseHandler.Paused += OnPaused;
        _playerHealth.Dead += OnDead;
        _levelEnder.Wined += OnWined;
    }

    private void OnDisable()
    {
        _playerHealth.Dead -= OnDead;
        _levelEnder.Wined -= OnWined;
    }

    private void OnDestroy()
    {
        _settingHandler.Toggled -= OnToggled;
        _cameraFollowBullet.Followed -= OnFollowed;
        _pauseHandler.Paused -= OnPaused;
    }

    private void OnPaused(bool isPaused)
    {
        gameObject.SetActive(!isPaused);
    }

    private void OnFollowed(bool isFollowed)
    {
        gameObject.SetActive(!isFollowed);
    }

    private void OnToggled(bool isActivated)
    {
        gameObject.SetActive(!isActivated);
    }

    private void OnWined()
    {
        gameObject.SetActive(false);
    }

    private void OnDead()
    {
        gameObject.SetActive(false);
    }
}
