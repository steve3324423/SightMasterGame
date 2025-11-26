using UnityEngine;
using UnityEngine.UI;

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
        _health.ChangedHealth += OnChangedHealth;
    }

    private void OnDestroy()
    {
        _health.ChangedHealth -= OnChangedHealth;
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(_camera.position.x,_camera.position.y,_camera.position.z));
    }

    private void OnChangedHealth(int value)
    {
        _slider.value = value;
    }
}
