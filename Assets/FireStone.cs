using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStone : MonoBehaviour, IWeapon
{
    [SerializeField] private ParticleSystem fireParticle;
    public void Shoot()
    {
        fireParticle.Play();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
