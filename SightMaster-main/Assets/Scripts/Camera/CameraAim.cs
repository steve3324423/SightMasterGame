using UnityEngine;
using Zenject;

[RequireComponent(typeof(CameraAimEnableHandler))]
public class CameraAim : MonoBehaviour
{
    private IInput _input;

    [Inject]
    public void Construct(IInput input)
    {
        _input = input;
    }

    private void Update()
    {
        transform.localRotation = _input.GetCameraRotation();
    }
}
