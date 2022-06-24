using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DummyState { Wet, Normal, Fire}
public class DummyStateController : MonoBehaviour
{
    [SerializeField] private Gradient dummyColorGradient;
    [SerializeField] private Material dummyMaterial;
    private DummyState _currentState;
    private float _stateValue;
    public DummyState CurrentState => _currentState;
    public float StateValue 
    {
        set
        {
            _stateValue = value;
            dummyMaterial.color = dummyColorGradient.Evaluate(_stateValue / 100);
        }
    }
    private void Start()
    {
        _currentState = DummyState.Normal;
        StateValue = 100;
    }
    public void Dry(float dryAmount)
    {
        
    }
    private void Update()
    {
        
    }
}
