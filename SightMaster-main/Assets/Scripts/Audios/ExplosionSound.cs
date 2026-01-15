using SightMaster.Scripts.Enviroment;
using UnityEngine;

namespace SightMaster.Scripts.Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class ExplosionSound : MonoBehaviour
    {
        [SerializeField] private Barrel[] _barrels;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            foreach (Barrel barrel in _barrels)
                barrel.Exploided += OnExploided;
        }

        private void OnDisable()
        {
            foreach (Barrel barrel in _barrels)
                barrel.Exploided -= OnExploided;
        }

        private void OnExploided()
        {
            _audioSource.Play();
        }
    }
}
