using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;

namespace SightMaster.Scripts.Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 70f;

        private float _timeForDestroy = .005f;
        private float _rotationSpeed = 10f;
        private Vector3 _direction;

        private void Start()
        {
            transform.LookAt(_direction);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.unscaledDeltaTime);
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.unscaledDeltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HeadEnemy enemy))
                Destroy(gameObject, _timeForDestroy);
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}
