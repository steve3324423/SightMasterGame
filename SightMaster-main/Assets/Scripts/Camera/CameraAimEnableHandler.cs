using System;
using SightMaster.Scripts.Weapon.Aim;
using UnityEngine;

namespace SightMaster.Scripts.Camera
{
    public class CameraAimEnableHandler : CameraEnableHandler
    {
        public event Action<bool> Aimed;

        protected override void OnWined()
        {
            if (IsFollowed == false)
                Camera.enabled = false;
        }

        protected override void OnFollowed(bool isFollowed)
        {
            Camera.enabled = !isFollowed;
            IsFollowed = isFollowed;
        }

        protected override void OnAimed(bool isAimed)
        {
            if (IsFollowed == false)
            {
                Camera.enabled = isAimed;
                Aimed?.Invoke(isAimed);
            }
        }
    }
}
