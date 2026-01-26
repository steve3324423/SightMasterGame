using UnityEngine;

namespace SightMaster.Scripts.FirstAidKit
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundFirstAidKit : MonoBehaviour
    {
        [SerializeField] private FirstAidKit _firstAidKit;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _firstAidKit.Taked += OnTaked;
        }

        private void OnDestroy()
        {
            _firstAidKit.Taked -= OnTaked;
        }

        private void OnTaked()
        {
            _audioSource.Play();
        }
    }
}
