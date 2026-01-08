using UnityEngine;

public interface IInput
{
    event System.Action<float, float> RotationValuesChanged;

    float Pitch { get; }
    float Yaw { get; }

    Vector3 GetDirection(Transform transform);
    Quaternion GetCameraRotation();
    void SetYaw(float yaw);
}