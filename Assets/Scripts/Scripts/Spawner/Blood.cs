using System.Collections;
using UnityEngine;

namespace SightMaster.Scripts.SpawnerObjects
{
    public class Blood : MonoBehaviour
    {
        private SpawnerBlood _spawner;
        private WaitForSeconds _waitSeconds;
        private float _timeForCoroutine = .5f;

        public void SetSpawner(SpawnerBlood spawner)
        {
            _spawner = spawner;
        }

        private void Awake()
        {
            _waitSeconds = new WaitForSeconds(_timeForCoroutine);
        }

        private void OnEnable()
        {
            StartCoroutine(DisableBlood());
        }

        private IEnumerator DisableBlood()
        {
            yield return _waitSeconds;
            _spawner.Pool.Release(this);
        }
    }
}
