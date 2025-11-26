using System;
using UnityEngine;

public class AimButton : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    public bool IsAimed { get; private set; }

    public event Action<bool> Aimed;

    private void OnEnable()
    {
        _playerHealth.Dead += OnDead;
    }

    private void OnDisable()
    {
        _playerHealth.Dead -= OnDead;
    }

    private void OnDead()
    {
        SetIsAimed();
    }

    public void Aim()
    {
        SetIsAimed();
    }

    public void SetIsAimed()
    {
        IsAimed = !IsAimed;
        Aimed?.Invoke(IsAimed);
    }
}
