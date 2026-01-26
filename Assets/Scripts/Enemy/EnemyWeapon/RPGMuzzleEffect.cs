using UnityEngine;

namespace SightMaster.Scripts.Enemy.EnemyWeapon
{
    public class RPGMuzzleEffect : BaseWeaponEffect
    {
        protected override void OnShooted()
        {
            _particleSystem.Play();
        }
    }
}
