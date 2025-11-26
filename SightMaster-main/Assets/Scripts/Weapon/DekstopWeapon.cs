using UnityEngine;

public class DekstopWeapon : IInputWeapon
{
    private bool _isCanGetValue = true;
    private PauseHandler _pauseHandler;
    private PlayerHealth _playerHealth;
    private LevelEnder _levelEnder;

    public DekstopWeapon(LevelEnder levelEnder, PlayerHealth playerHealth,PauseHandler pauseHandler)
    {
        _levelEnder = levelEnder;
        _playerHealth = playerHealth;
        _pauseHandler = pauseHandler;

        _pauseHandler.Paused += OnPaused;
        _levelEnder.Wined += OnWined;
        _playerHealth.Dead += OnDead;
    }

    private void OnWined()
    {
        _isCanGetValue = false;
    }

    private void OnDead()
    {
        _isCanGetValue = false;
    }

    private void OnPaused(bool isPaused)
    {
        _isCanGetValue = !isPaused;
    }

    public bool IsAimed()
    {
        if (_isCanGetValue)
            return Input.GetMouseButton(1);

        return false;
    }

    public bool IsShoot()
    {
        if (_isCanGetValue)
            return Input.GetMouseButton(0);

        return false;
    }
}
