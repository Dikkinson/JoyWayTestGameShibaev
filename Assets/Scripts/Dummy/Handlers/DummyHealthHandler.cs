using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealthHandler : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private ValueBar healthBar;
    private float currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaximumValue(MaxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        healthBar.currentValue = currentHealth;
    }

    public void RestoreHealth()
    {
        currentHealth = MaxHealth;
        healthBar.currentValue = currentHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
