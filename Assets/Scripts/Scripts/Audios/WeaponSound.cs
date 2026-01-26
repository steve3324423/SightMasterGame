using SightMaster.Scripts.Weapon;
using SightMaster.Scripts.Weapon.Sound;
using UnityEngine;

namespace SightMaster.Scripts.Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponSound : MonoBehaviour
    {
        [SerializeField] private AmmoHandler[] _ammos;

        private AudioSource _audioSource;
        private AudioClip _clip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            foreach (AmmoHandler ammo in _ammos)
                ammo.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            foreach (AmmoHandler ammo in _ammos)
                ammo.Shooted -= OnShooted;
        }

        private void SetClip()
        {
            foreach (AmmoHandler ammo in _ammos)
            {
                if (ammo.gameObject.activeSelf)
                    _audioSource.clip = ammo.GetComponent<SoundGet>().GetClip();
            }
        }

        private void OnShooted()
        {
            if (_audioSource.clip == null)
                SetClip();

            _audioSource.Play();
        }
    }
}
