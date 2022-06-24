using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private DummyHealthHandler healthController;
    private DummyStateController stateController;
    private void Awake()
    {
        healthController = GetComponent<DummyHealthHandler>();
        stateController = GetComponent<DummyStateController>();
    }
    public void Restore()
    {
        healthController.RestoreHealth();
    }
    public void TakePistolDamage(float baseDamage)
    {
        
    }
    public void TakeFireDamage()
    {
        if (stateController.CurrentState == DummyState.Wet)
        {

        }
    }
}
