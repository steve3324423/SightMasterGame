using System;
using UnityEngine;

public abstract class InputControl : IInput
{
    private float _xRotation;
    private float _yRotation;
    private float _zRotation = 0f;
    protected bool IsCanGetValue = true;
    private PlayerHealth _playerHealth;
    private LevelEnder _levelEnder;

    public event Action<float, float> RotationValuesChanged;

    public InputControl(LevelEnder levelEnder, PlayerHealth playerHealth)
    {
        _levelEnder = levelEnder;
        _playerHealth = playerHealth;

        _levelEnder.Wined += OnWined;
        _playerHealth.Dead += OnDead;
    }

    public virtual Vector3 GetDirection(Transform transformPlayer)
    {
        return Vector3.zero;
    }

    public abstract Quaternion GetCameraRotation();

    protected Quaternion SetCameraRotation(float xValue,float yValue)
    {
        _xRotation = xValue;
        _yRotation = yValue;

        RotationValuesChanged?.Invoke(xValue, yValue);
        return Quaternion.Euler(_xRotation, _yRotation, _zRotation);
    }

    private void OnWined()
    {
        IsCanGetValue = false;
    }

    private void OnDead()
    {
        IsCanGetValue = false;
    }
}
