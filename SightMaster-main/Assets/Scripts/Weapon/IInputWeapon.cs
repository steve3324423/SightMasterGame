using System;
using UnityEngine;

namespace SightMaster.Scripts.Weapon
{
    public interface IInputWeapon
    {
        bool IsAimed();

        bool IsShoot();
    }
}
