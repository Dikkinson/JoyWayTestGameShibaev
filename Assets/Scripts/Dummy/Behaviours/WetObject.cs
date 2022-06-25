using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetObject : MonoBehaviour
{
    [SerializeField] private ValueBar wetValueBar;
    [SerializeField] private float maximumWetValue;
    [SerializeField] private Color wetColor;
    [SerializeField] private float dryAmountPerFireParticle = 1f;//missile
    
    private DummyView dummyView;
    private bool _isWet;
    private float _wetValue;

    public float WetValue 
    {
        get => _wetValue;
        set
        {
            _wetValue = value;
            _wetValue = Mathf.Clamp(_wetValue, 0, maximumWetValue);
            IsWet = _wetValue > 0;
            wetValueBar.currentValue = _wetValue;
        }
    }

    public bool IsWet 
    {
        get => _isWet;
        set
        {
            _isWet = value;
            if (_isWet)
                dummyView.ChangeColor(wetColor);
            else
                dummyView.ResetColor();
        }
    }

    private void Awake()
    {
        dummyView = GetComponent<DummyView>();
    }

    void Start()
    {
        _wetValue = 0;
        wetValueBar.SetMaximumValue(maximumWetValue);
        wetValueBar.currentValue = _wetValue;
    }
}
