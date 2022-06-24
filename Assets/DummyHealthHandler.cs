using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealthHandler : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaximumHealth(MaxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        healthBar.CurrentHealth = currentHealth;
    }

    public void RestoreHealth()
    {
        currentHealth = MaxHealth;
        healthBar.CurrentHealth = currentHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
