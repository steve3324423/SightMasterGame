using System;
using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.DamageObject;
using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;

namespace SightMaster.Scripts.Weapon
{
    public class RayWeapon : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private Camera _camera;

        private AmmoHandler _weaponAmmo;
        private float _positionCameraScreen = .5f;
        private float _defaultPositionValue = 0f;
        private RaycastHit _hit;

        public event Action<Vector3, Vector3> HitedBody;
        public event Action<Vector3, Vector3> HitedHead;

        private void Awake()
        {
            _weaponAmmo = GetComponent<AmmoHandler>();
        }

        private void OnEnable()
        {
            _weaponAmmo.Shooted += OnShooted;
        }

        private void OnDestroy()
        {
            _weaponAmmo.Shooted -= OnShooted;
        }

        private void OnShooted()
        {
            Ray ray = _camera.ViewportPointToRay(new Vector3(_positionCameraScreen, _positionCameraScreen, _defaultPositionValue));

            if (Physics.Raycast(ray, out _hit) && _hit.collider.TryGetComponent(out IDamageObject damageObject))
            {
                damageObject.TakeDamage(_damage);

                if (_hit.collider.TryGetComponent(out EnemyHealth enemy))
                    HitedBody?.Invoke(_hit.point, _hit.normal);

                if (_hit.collider.TryGetComponent(out HeadEnemy head))
                    HitedHead?.Invoke(_hit.point, _hit.normal);
            }
        }
    }
}
