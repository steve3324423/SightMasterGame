using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private EnemyWeapon[] _weapons;

    private int _maxValue = 100;
    private int _minValue = 0;

    public  int Health { get; private set; } = 100;

    public event Action<int> HealthChanged;
    public event Action Dead;

    private void OnEnable()
    {
        foreach (EnemyWeapon weapon in _weapons)
            weapon.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        foreach (EnemyWeapon weapon in _weapons)
            weapon.Shooted -= OnShooted;
    }

    public void SetHealth(int value)
    {
        if(value > _minValue && value <= _maxValue)
        {
            Health = value;
            HealthChanged?.Invoke(Health);
        }
    }

    private void OnShooted(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Dead?.Invoke();
            return;
        }
        HealthChanged?.Invoke(Health);
    }
}
