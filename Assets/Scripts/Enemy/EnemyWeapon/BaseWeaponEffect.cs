using UnityEngine;

namespace SightMaster.Scripts.Enemy.EnemyWeapon
{
    public abstract class BaseWeaponEffect : MonoBehaviour
    {
        [SerializeField] protected EnemyWeapon _weapon;

        protected ParticleSystem _particleSystem;

        protected virtual void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        protected virtual void OnEnable()
        {
            _weapon.Shooted += OnShooted;
        }

        protected virtual void OnDisable()
        {
            _weapon.Shooted -= OnShooted;
        }

        protected abstract void OnShooted();
    }
}