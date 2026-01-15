using SightMaster.Scripts.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(Slider))]
    public class WaveBar : MonoBehaviour
    {
        [SerializeField] private WaveSpawned[] _waveSpawned;

        private int _defaultValue = 1;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.maxValue = _waveSpawned.Length;
            _slider.value = _defaultValue;
        }

        private void OnEnable()
        {
            foreach (WaveSpawned wave in _waveSpawned)
                wave.Activated += OnActivated;
        }

        private void OnDisable()
        {
            foreach (WaveSpawned enemy in _waveSpawned)
                enemy.Activated -= OnActivated;
        }

        private void OnActivated()
        {
            _slider.value++;
        }
    }
}
