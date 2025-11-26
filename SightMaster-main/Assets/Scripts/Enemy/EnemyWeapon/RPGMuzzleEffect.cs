using UnityEngine;

public class RPGMuzzleEffect : MonoBehaviour
{
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
        _particleSystem.Play();
    }
}
