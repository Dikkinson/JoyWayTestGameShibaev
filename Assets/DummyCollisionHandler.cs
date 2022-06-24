using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollisionHandler : MonoBehaviour
{
    private Dummy dummy;
    private void Awake()
    {
        dummy = GetComponent<Dummy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            dummy.TakeDamage(1);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
