using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMissile : MissileBase
{
    public float wetAmount;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
