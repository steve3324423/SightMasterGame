using UnityEngine;

namespace SightMaster.Scripts.Enemy
{
    public class WaveDirector : MonoBehaviour
    {
        [SerializeField] private WaveDestroyHandler[] _waveDestroyHandlers;
        [SerializeField] private WaveSpawned[] _waveSpawneds;

        private int _index;

        private void OnEnable()
        {
            foreach (WaveDestroyHandler waveDestroyHandler in _waveDestroyHandlers)
                waveDestroyHandler.Destroyed += OnDestroyed;
        }

        private void OnDisable()
        {
            foreach (WaveDestroyHandler waveDestroyHandler in _waveDestroyHandlers)
                waveDestroyHandler.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            if (_index == _waveSpawneds.Length - 1)
                return;

            _index++;
            _waveSpawneds[_index].Start—ountdown();
        }
    }
}