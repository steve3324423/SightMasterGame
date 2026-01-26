using UnityEngine;

namespace SightMaster.Scripts.Enemy.EnemyWeapon
{
    [RequireComponent(typeof(ParticleSystem))]
    public class MuzzleEffect : BaseWeaponEffect
    {
        protected override void OnShooted()
        {
            _particleSystem.Play();
        }
    }
}
