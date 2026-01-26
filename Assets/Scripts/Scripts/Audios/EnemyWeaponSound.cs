using SightMaster.Scripts.Enemy.EnemyWeapon;
using SightMaster.Scripts.Player;
using UnityEngine;

namespace SightMaster.Scripts.Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemyWeaponSound : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private WeaponDeadHandler _weaponDeadHandler;
        [SerializeField] private EnemyWeapon _enemyWeapon;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _playerHealth.Dead += OnDead;
            _weaponDeadHandler.Falled += OnFalled;
            _enemyWeapon.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            _playerHealth.Dead -= OnDead;
            _weaponDeadHandler.Falled -= OnFalled;
            _enemyWeapon.Shooted -= OnShooted;
        }

        private void OnShooted()
        {
            _audioSource.Play();
        }

        private void OnDead()
        {
            _audioSource.Stop();
        }

        private void OnFalled()
        {
            _audioSource.Stop();
        }
    }
}
