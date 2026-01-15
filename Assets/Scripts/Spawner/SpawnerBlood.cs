using UnityEngine;

namespace SightMaster.Scripts.SpawnerObjects
{
    public class SpawnerBlood : Spawner<Blood>
    {
        [SerializeField] private Blood _blood;

        private Vector3 _spawnPosition;
        private Vector3 _rotate;

        public void SetPositionAndRotate(Vector3 spawnPosition, Vector3 rotate)
        {
            _spawnPosition = spawnPosition;
            _rotate = rotate;
        }

        protected override Blood Create()
        {
            Blood newBlood = Instantiate(_blood, _spawnPosition, Quaternion.LookRotation(_rotate));
            newBlood.SetSpawner(this);
            return newBlood;
        }

        protected override void OnTakeFromPool(Blood objectGame)
        {
            objectGame.transform.position = _spawnPosition;
            objectGame.transform.rotation = Quaternion.LookRotation(_rotate);
            base.OnTakeFromPool(objectGame);
        }
    }
}
