using System;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class ShootButton : MonoBehaviour
    {
        private float _timeForInvoke = .01f;

        public bool IsClickShoot { get; private set; }
        public event Action<bool> Shooting;

        public void Shoot()
        {
            IsClickShoot = true;
            Shooting?.Invoke(IsClickShoot);
            Invoke("DisableShoot", _timeForInvoke);
        }

        private void DisableShoot()
        {
            IsClickShoot = false;
            Shooting?.Invoke(IsClickShoot);
        }
    }
}
