using SightMaster.Scripts.DamageObject;
using System;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class PlayerHealth : HealthSystem
    {
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}