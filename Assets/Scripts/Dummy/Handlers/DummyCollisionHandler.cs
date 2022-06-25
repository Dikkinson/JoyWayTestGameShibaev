using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollisionHandler : MonoBehaviour
{
    private DummyDamageHandler dummyDamageHandler;
    private void Awake()
    {
        dummyDamageHandler = GetComponent<DummyDamageHandler>();
    }
    private void OnParticleCollision(GameObject other)
    {
        HandleCollison(other);
    }
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollison(collision.gameObject);
    }
    private void HandleCollison(GameObject collisonObject)
    {
        MissileBase damageSource = collisonObject.GetComponent<MissileBase>();
        if (damageSource != null)
        {
            dummyDamageHandler.TakeDamage(damageSource);
        }
    }
}
