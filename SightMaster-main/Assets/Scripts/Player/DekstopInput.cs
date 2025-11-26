using System;
using UnityEngine;
using YG;

public class DekstopInput : InputControl
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private CameraAimEnableHandler _cameraAim;
    private float _degree = 45f;
    private float _xValue = 0f;
    private float _yValue = 0f;
    private bool _isAimed;

    public DekstopInput(LevelEnder levelEnder, PlayerHealth playerHealth,CameraAimEnableHandler cameraAim) : base(levelEnder, playerHealth) 
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cameraAim = cameraAim;

        _cameraAim.Aimed += OnAimed;
    }

    public override Vector3 GetDirection(Transform transformPlayer)
    {
        if(IsCanGetValue)
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);

            return transformPlayer.right * horizontal + transformPlayer.forward * vertical;
        }

        return base.GetDirection(transformPlayer);
    }

    public override Quaternion GetCameraRotation()
    {
        float mouseX = Input.GetAxis(MouseX) * YG2.saves.sensitivityMobile; ;
        float mouseY = Input.GetAxis(MouseY) * YG2.saves.sensitivityMobile; ;

        _yValue += mouseX;
        _xValue -= mouseY;

        _yValue = Mathf.Clamp(_yValue, -_degree, _degree);
        _xValue = Mathf.Clamp(_xValue, -_degree, _degree);

        return SetCameraRotation(_xValue,_yValue);
    }

    private void OnAimed(bool isAimed)
    {
        _isAimed = isAimed;
    }
}
