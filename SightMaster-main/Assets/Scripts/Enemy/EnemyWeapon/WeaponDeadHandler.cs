using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WeaponDeadHandler : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;

    private Rigidbody _rigidbody;

    public event Action Falled;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _health.Dead += OnDead;
    }

    private void OnDisable()
    {
        _health.Dead -= OnDead;
    }

    private void OnDead()
    {
        _rigidbody.isKinematic = false;
        transform.parent = null;

        Falled?.Invoke();
    }
}
