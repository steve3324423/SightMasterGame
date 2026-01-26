using SightMaster.Scripts.Enemy.HealthHandler;
using UnityEngine;
using UnityEngine.UI;

namespace SightMaster.Scripts.UI
{
    public class HealthBarEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private Transform _camera;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += OnChangedHealth;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnChangedHealth;
        }

        private void LateUpdate()
        {
            transform.LookAt(new Vector3(_camera.position.x, _camera.position.y, _camera.position.z));
        }

        private void OnChangedHealth(int value)
        {
            _slider.value = value;
        }
    }
}
