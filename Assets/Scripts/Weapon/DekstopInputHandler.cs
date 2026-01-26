using System;
using UnityEngine;

public class DekstopInputHandler : MonoBehaviour
{
    public event Action<bool> Shooting;
    public event Action<bool> Aiming;

    private void Update()
    {
        bool currentShootState = Input.GetMouseButton(0);
        bool currentAimState = Input.GetMouseButton(1);

        Shooting?.Invoke(currentShootState);
        Aiming?.Invoke(currentAimState);
    }
}