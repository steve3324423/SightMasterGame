using SightMaster.Scripts.CameraHandlers;
using UnityEngine;

namespace SightMaster.Scripts.Enemy.EnemyWeapon
{
    public class RPGExplosionEffect : BaseWeaponEffect
    {
        [SerializeField] private CameraAim _cameraAim;

        protected override void OnShooted()
        {
            transform.position = _cameraAim.transform.position;
            _particleSystem.Play();
        }
    }
}
