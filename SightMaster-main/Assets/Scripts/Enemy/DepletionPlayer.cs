using System;
using UnityEngine;

public class DepletionPlayer : MonoBehaviour
{
    [SerializeField] private CameraFollowBullet _cameraFollowBullet;
    [SerializeField] private WeaponAmmo[] _ammos;
    [SerializeField] private int _deplectionChance = 1;
    [SerializeField] private int _minValue = 0;
    [SerializeField] private int _maxValue = 2;

    private float _timeForInvoke = .1f;
    private EnemyHealth _enemyHealth;
    private bool _canDepletion = true;
    private bool _canScared = true;

    public event Action Scared;
    public event Action Depleted;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        foreach (WeaponAmmo weapon in _ammos)
            weapon.Shooted += OnShooted;

        _cameraFollowBullet.Followed += OnFollowed;
        _enemyHealth.Dead += OnDead;
    }

    private void OnDisable()
    {
        foreach (WeaponAmmo weapon in _ammos)
            weapon.Shooted -= OnShooted;

        _cameraFollowBullet.Followed -= OnFollowed;
        _enemyHealth.Dead -= OnDead;
    }

    private void OnShooted()
    {
        Invoke("ReactedToShoot", _timeForInvoke);
    }

    private void ReactedToShoot()
    {
        int randomMumber = UnityEngine.Random.Range(_minValue, _maxValue);

        if (randomMumber == _deplectionChance && _canDepletion)
        {
            Depleted?.Invoke();
            _canScared = false;
            _canDepletion = false;
        }
        else if (_canDepletion && _canScared)
        {
            _canScared = false;
            Scared?.Invoke();
        }
    }

    private void OnFollowed(bool isFollowed)
    {
        _canDepletion = !isFollowed;

        if (_canDepletion && _canScared)
            ReactedToShoot();
    }

    private void OnDead()
    {
        _canDepletion = false;
        _canScared = false;
        enabled = false;
    }
}
