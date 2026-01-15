using UnityEngine;
using UnityEngine.Pool;

namespace SightMaster.Scripts.SpawnerObjects
{
    public abstract class Spawner<T> : MonoBehaviour
    where T : Component
    {
        private bool _collectionChecks = true;
        private int _defaultCapacity = 10;
        private int _maxCapacity = 100;

        public ObjectPool<T> Pool { get; private set; }

        private void Awake()
        {
            Pool = new ObjectPool<T>(Create, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, _collectionChecks, _defaultCapacity, _maxCapacity);
        }

        protected abstract T Create();

        protected virtual void OnTakeFromPool(T objectGame)
        {
            objectGame.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(T objectGame)
        {
            objectGame.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(T objectGame)
        {
            Destroy(objectGame.gameObject);
        }
    }
}
