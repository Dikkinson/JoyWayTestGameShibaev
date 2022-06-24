using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private LayerMask shootingLayers;
    [SerializeField] private float baseDamage;
    [SerializeField] private GameObject bulletImpact;
    [SerializeField] private ParticleSystem flashParticle;

    private Transform mainCameraTransform;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit, shootingLayers))
        {
            Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            flashParticle.Play();

            hit.collider.GetComponentInParent<Dummy>()?.TakePistolDamage(baseDamage);
        }
    }
}
