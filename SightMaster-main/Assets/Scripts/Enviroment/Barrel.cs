using System;
using UnityEngine;

public class Barrel : MonoBehaviour , IDamageObject
{
    [SerializeField] private GameObject _explosionEffect;

    public event Action Exploided;

    public void TakeDamage(int damage)
    {
        Exploided?.Invoke();
        Instantiate(_explosionEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
