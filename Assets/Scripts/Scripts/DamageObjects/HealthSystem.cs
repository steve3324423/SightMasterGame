using System;
using UnityEngine;

namespace SightMaster.Scripts.DamageObject
{
    public abstract class HealthSystem : MonoBehaviour, IDamageObject
    {
        [SerializeField] protected int maxHealth = 100;
        [SerializeField] protected int minHealth = 0;
        [SerializeField] protected int startingHealth = 100;

        public event Action<int> HealthChanged;
        public event Action Dead;

        public int CurrentHealth { get; protected set; }
        public int MaxHealth => maxHealth;
        public int MinHealth => minHealth;

        protected virtual void Awake()
        {
            CurrentHealth = startingHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            if (damage <= 0 || IsDead())
                return;

            CurrentHealth -= damage;
            CurrentHealth = Mathf.Max(CurrentHealth, minHealth);

            HealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= minHealth)
            {
                Die();
            }
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || IsDead())
                return;

            CurrentHealth += amount;
            CurrentHealth = Mathf.Min(CurrentHealth, maxHealth);
            HealthChanged?.Invoke(CurrentHealth);
        }

        public void SetHealth(int value)
        {
            value = Mathf.Clamp(value, minHealth, maxHealth);
            CurrentHealth = value;
            HealthChanged?.Invoke(CurrentHealth);
        }

        public float GetHealthPercentage()
        {
            return (float)CurrentHealth / maxHealth;
        }

        public bool IsDead()
        {
            return CurrentHealth <= minHealth;
        }

        protected virtual void Die()
        {
            Dead?.Invoke();
        }
    }
}