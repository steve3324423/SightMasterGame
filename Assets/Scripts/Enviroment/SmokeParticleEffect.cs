using System.Collections.Generic;
using SightMaster.Scripts.Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace SightMaster.Scripts.Enviroment
{
    [RequireComponent(typeof(SmokePool))]
    public class SmokeParticleEffect : MonoBehaviour
    {
        [SerializeField] private WaveSpawned[] _wavesSpawned;

        private SmokePool _smokePool;
        private ObjectPool<ParticleSystem> _pool;

        private void Awake()
        {
            _smokePool = GetComponent<SmokePool>();
        }

        private void Start()
        {
            _pool = _smokePool.GetPool();
        }

        private void OnEnable()
        {
            foreach (WaveSpawned wave in _wavesSpawned)
                wave.WarningBeforeSpawned += OnWarningBeforeSpawned;
        }

        private void OnDisable()
        {
            foreach (WaveSpawned wave in _wavesSpawned)
                wave.WarningBeforeSpawned -= OnWarningBeforeSpawned;
        }

        private void OnWarningBeforeSpawned(List<GameObject> childs)
        {
            for (int i = 0; i < childs.Count; i++)
            {
                _smokePool.SetPosition(childs[i].transform);
                _pool.Get();
            }
        }
    }
}
