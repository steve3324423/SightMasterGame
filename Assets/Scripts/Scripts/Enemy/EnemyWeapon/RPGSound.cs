using UnityEngine;

namespace SightMaster.Scripts.Enemy.EnemyWeapon
{
    [RequireComponent(typeof(AudioSource))]
    public class RPGSound : MonoBehaviour
    {
        [SerializeField] private EnemyWeapon _enemyWeapon;

        private AudioSource _audio;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _enemyWeapon.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            _enemyWeapon.Shooted -= OnShooted;
        }

        private void OnShooted()
        {
            _audio.Play();
        }
    }
}