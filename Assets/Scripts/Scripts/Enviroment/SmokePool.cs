using System.Collections;
using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;
using UnityEngine.Pool;

namespace SightMaster.Scripts.Enviroment
{
    public class SmokePool : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private EnemyHealth[] _enemies;

        private WaitForSeconds _waitForSeconds;
        private ParticleSystem _smokeEffect;
        private ObjectPool<ParticleSystem> _pool;
        private Transform _enemyPosition;
        private float _timeForCoroutine = 5f;
        private int _maxSizePool = 10000;
        private int _minSizePool = 100;

        public ObjectPool<ParticleSystem> GetPool()
        {
            return _pool;
        }

        private void Awake()
        {
            _pool = new ObjectPool<ParticleSystem>(CreateItem, ActionSmokeFromPool, ReleaseParticleFromPool, DestroyActionFromPool, false, _minSizePool, _maxSizePool);
            _waitForSeconds = new WaitForSeconds(_timeForCoroutine);
        }

        private ParticleSystem CreateItem()
        {
            _smokeEffect = Instantiate(_particleSystem, _enemyPosition.transform.position, Quaternion.identity);
            return _smokeEffect;
        }

        private void ActionSmokeFromPool(ParticleSystem particleSystem)
        {
            particleSystem.transform.position = _enemyPosition.position;
            particleSystem.gameObject.SetActive(true);
            StartCoroutine(ReleasedToPool(particleSystem));
        }

        private void ReleaseParticleFromPool(ParticleSystem particleSystem)
        {
            particleSystem.gameObject.SetActive(false);
        }

        private void DestroyActionFromPool(ParticleSystem particleSystem)
        {
            Destroy(particleSystem);
        }

        private IEnumerator ReleasedToPool(ParticleSystem particleSystem)
        {
            yield return _waitForSeconds;
            _pool.Release(particleSystem);
        }

        public void SetPosition(Transform enemyPosition)
        {
            _enemyPosition = enemyPosition;
        }
    }
}
