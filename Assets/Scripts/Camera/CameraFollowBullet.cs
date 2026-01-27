using System;
using System.Collections;
using SightMaster.Scripts.Weapon;
using SightMaster.Scripts.Weapon.Bullet;
using UnityEngine;

namespace SightMaster.Scripts.CameraHandlers
{
    public class CameraFollowBullet : MonoBehaviour
    {
        [SerializeField] private RayWeapon[] _raysWeapon;
        [SerializeField] private BulletSpawn _bulletSpawn;
        [SerializeField] private float _cameraSpeed = 1f;

        private float _slowdownFactor = 0.1f;
        private float _slowdownLength = 1.5f;
        private float _cameraDistance = 2f;
        private Vector3 _hitPosition;
        private Bullet _followingBullet;

        public event Action<bool> Followed;

        private void OnEnable()
        {
            foreach (RayWeapon weapon in _raysWeapon)
                weapon.HitedHead += OnHited;

            _bulletSpawn.Created += OnCreated;
        }

        private void OnDisable()
        {
            foreach (RayWeapon weapon in _raysWeapon)
                weapon.HitedHead -= OnHited;

            _bulletSpawn.Created -= OnCreated;
        }

        private IEnumerator DoSlowMotion()
        {
            Time.timeScale = _slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            Vector3 originalCameraPosition = transform.position;
            Quaternion originalCameraRotation = transform.rotation;
            Vector3 targetCameraPosition;

            float timer = 0;

            while (timer < _slowdownLength)
            {
                timer += Time.unscaledDeltaTime;

                targetCameraPosition = _hitPosition - (_followingBullet.transform.position * _cameraDistance);
                transform.position = Vector3.Lerp(transform.position, targetCameraPosition, Time.unscaledDeltaTime * _cameraSpeed);
                transform.LookAt(_hitPosition);

                yield return null;
            }

            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;

            _followingBullet = null;

            Followed?.Invoke(false);

            transform.position = originalCameraPosition;
            transform.rotation = originalCameraRotation;
        }

        private void OnCreated(Bullet bullet)
        {
            _followingBullet = bullet;
            Followed?.Invoke(true);
            StartCoroutine(DoSlowMotion());
        }

        private void OnHited(Vector3 position, Vector3 rotation)
        {
            _hitPosition = position;
        }
    }
}