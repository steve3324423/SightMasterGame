using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageObject
{
    private HeadEnemy _head;
    protected float TimeForDead = 1.7f;
    private int _health = 100;
    private bool _isDead;

    public event Action<int> ChangedHealth;
    public event Action Dead;

    private void Awake()
    {
        _head = GetComponentInChildren<HeadEnemy>();
    }

    private void OnEnable()
    {
        _head.Hited += OnHited;
    }

    private void OnDisable()
    {
        _head.Hited -= OnHited;
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0 && _isDead == false)
        {
            Dead?.Invoke();
            Disable();

            _isDead = true;
        }

        ChangedHealth?.Invoke(_health);
    }

    protected virtual void Disable()
    {
        Destroy(gameObject, TimeForDead);
    }

    private void OnHited(int damage)
    {
        TakeDamage(damage);
    }
}
