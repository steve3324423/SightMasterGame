using System;
using UnityEngine;
using Zenject;

public class Aim : MonoBehaviour
{
    private IInputWeapon _inputWeapon;

    public event Action<bool> Aimed;

    [Inject]
    public void Construct(IInputWeapon inputWeapon)
    {
        _inputWeapon = inputWeapon;
    }

    private void Update()
    {
        Aimed?.Invoke(_inputWeapon.IsAimed());
    }
}
