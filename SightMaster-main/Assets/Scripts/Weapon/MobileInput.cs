using UnityEngine;

public class MobileInput : IInputWeapon
{
    private AimButton _aimButtom;
    private ShootButton _shootButton;

    public MobileInput(AimButton aimButtom,ShootButton shootButton)
    {
        _aimButtom = aimButtom;
        _shootButton = shootButton;
    }

    public bool IsAimed()
    {
        return _aimButtom.IsAimed;
    }

    public bool IsShoot()
    {
        return _shootButton.IsClickShoot;
    }
}
