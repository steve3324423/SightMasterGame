using SightMaster.Scripts.SpawnerObjects;
using SightMaster.Scripts.Weapon;
using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    public class EnemyBlood : MonoBehaviour
    {
        [SerializeField] private RayWeapon[] _rays;
        [SerializeField] private SpawnerBlood _spawner;

        private void OnEnable()
        {
            foreach (RayWeapon weapon in _rays)
            {
                weapon.HitedHead += OnHitedHead;
                weapon.HitedBody += OnHited;
            }
        }

        private void OnDisable()
        {
            foreach (RayWeapon weapon in _rays)
            {
                weapon.HitedHead -= OnHitedHead;
                weapon.HitedBody -= OnHited;
            }
        }

        private void SpawnerActive(Vector3 normal, Vector3 point)
        {
            _spawner.SetPositionAndRotate(normal, point);
            _spawner.Pool.Get();
        }

        private void OnHited(Vector3 normal, Vector3 point)
        {
            SpawnerActive(normal, point);
        }

        private void OnHitedHead(Vector3 normal, Vector3 point)
        {
            SpawnerActive(normal, point);
        }
    }
}
