using UnityEngine;

public class RPGExplosionEffect : MonoBehaviour
{
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private EnemyWeapon _weapon;

    private ParticleSystem _particleSystem;

    private void Awake()
    { 
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        _weapon.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        _weapon.Shooted -= OnShooted;
    }

    private void OnShooted(int value)
    {
        transform.position = _cameraAim.transform.position;
        _particleSystem.Play();
    }
}
