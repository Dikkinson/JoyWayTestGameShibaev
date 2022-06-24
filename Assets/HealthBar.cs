using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient healthBarColorGradient;
    [SerializeField] private Text healthText;
    [SerializeField] private Image fillImage;

    private Slider healthSlider;
    private float _maxHealth;
    private float _currentHealth;
    public float CurrentHealth 
    { 
        set
        {
            _currentHealth = value;
            healthText.text = $"{_currentHealth}/{_maxHealth}";
            healthSlider.value = _currentHealth / _maxHealth;
            fillImage.color = healthBarColorGradient.Evaluate(_currentHealth / _maxHealth);
        }
    }

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    public void SetMaximumHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
        CurrentHealth = _maxHealth;
    }
}
