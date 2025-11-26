using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyTakeExplosion : EnviromentTakeExplosion
{
    private EnemyHealth _enemyHealth;
    private int _damage = 100;

    protected override void Awake()
    {
        base.Awake();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    public override void TakeExplosion()
    {
        base.TakeExplosion();
        _enemyHealth.TakeDamage(_damage);
    }
}
