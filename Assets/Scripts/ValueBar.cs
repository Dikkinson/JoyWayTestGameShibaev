using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    [SerializeField] private Gradient barColorGradient;
    [SerializeField] private Text textValueView;
    [SerializeField] private Image sliderFillImage;

    private Slider sliderBar;
    private float _maxValue;
    private float _currentValue;
    public float currentValue
    { 
        set
        {
            _currentValue = value;
            textValueView.text = $"{_currentValue}/{_maxValue}";
            sliderBar.value = _currentValue / _maxValue;
            sliderFillImage.color = barColorGradient.Evaluate(_currentValue / _maxValue);
        }
    }

    private void Awake()
    {
        sliderBar = GetComponent<Slider>();
    }

    public void SetMaximumValue(float maxValue)
    {
        _maxValue = maxValue;
        currentValue = _maxValue;
    }
}
