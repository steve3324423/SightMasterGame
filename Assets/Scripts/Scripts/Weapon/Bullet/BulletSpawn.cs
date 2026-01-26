using System;
using UnityEngine;

namespace SightMaster.Scripts.Weapon.Bullet
{
    public class BulletSpawn : MonoBehaviour
    {
        [SerializeField] private Transform _positionSpawn;
        [SerializeField] private RayWeapon[] _rayWeapons;
        [SerializeField] private Bullet _bullet;

        public event Action<Bullet> Created;

        private void OnEnable()
        {
            foreach (RayWeapon weapon in _rayWeapons)
                weapon.HitedHead += OnHitedHead;
        }

        private void OnDisable()
        {
            foreach (RayWeapon weapon in _rayWeapons)
                weapon.HitedHead -= OnHitedHead;
        }

        private void OnHitedHead(Vector3 position, Vector3 rotation)
        {
            Bullet bullet = Instantiate(_bullet, _positionSpawn.position, Quaternion.identity);
            bullet.SetDirection(position);
            Created?.Invoke(_bullet);
        }
    }
}