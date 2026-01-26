using SightMaster.Scripts.Enemy;
using TMPro;
using UnityEngine;

namespace SightMaster.Scripts.UI
{
    public class WaveCountText : MonoBehaviour
    {
        [SerializeField] private WaveSpawned[] _waveSpawned;

        private TextMeshProUGUI _text;
        private int _countWave = 1;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            SetText();
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
            _countWave++;
            SetText();
        }

        private void SetText()
        {
            _text.text = $"{_countWave}/{_waveSpawned.Length}";
        }
    }
}
