using System;

namespace SightMaster.Scripts.Weapon
{
    public interface IInputWeapon
    {
        event Action<bool> Aiming;

        event Action<bool> Shooting;
    }
}
