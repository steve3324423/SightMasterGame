using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class MuzzleEffect : MonoBehaviour
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

    private void OnDestroy()
    {
        _weapon.Shooted -= OnShooted;
    }

    private void OnShooted(int damage)
    {
        _particleSystem.Play();
    }
}
