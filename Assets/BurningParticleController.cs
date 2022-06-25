using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningParticleController : MonoBehaviour
{
    private ParticleSystem burningParticle;

    private void Awake()
    {
        burningParticle = GetComponent<ParticleSystem>();
    }

    public void PlayFireParticle(float duration)
    {
        StopBurningParticle();
        var main = burningParticle.main;
        main.duration = duration;
        burningParticle.Play();
    }

    public void StopBurningParticle()
    {
        burningParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
