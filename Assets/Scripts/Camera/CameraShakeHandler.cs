using System.Collections;
using SightMaster.Scripts.Weapon;
using UnityEngine;

namespace SightMaster.Scripts.CameraHandlers
{
    public class CameraShakeHandler : MonoBehaviour
    {
        [SerializeField] private AmmoHandler[] _weaponAmmo;

        private float _speed = 30f;

        private void OnEnable()
        {
            foreach (AmmoHandler weapon in _weaponAmmo)
                weapon.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            foreach (AmmoHandler weapon in _weaponAmmo)
                weapon.Shooted -= OnShooted;
        }

        private void OnShooted()
        {
            StartCoroutine(Recoil());
        }

        private IEnumerator Recoil()
        {
            float time = .28f;
            Vector3 initialRotation = transform.localEulerAngles;
            Vector3 recoilDirection = GetRandomRecoilDirection();

            while (time > 0)
            {
                yield return null;

                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles + recoilDirection, initialRotation, _speed * Time.deltaTime);
                time -= Time.deltaTime;
            }
        }

        private Vector3 GetRandomRecoilDirection()
        {
            float minValue = 5f;
            float maxValue = 20f;

            float xValue = Random.Range(minValue, maxValue);
            float zValue = Random.Range(-maxValue, maxValue);

            return new Vector3(-xValue, 0, zValue);
        }
    }
}