using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private LayerMask shootingLayers;
    [SerializeField] private GameObject bulletImpactPrefab;
    [SerializeField] private ParticleSystem flashParticle;

    private MissileBase missile;
    private Transform mainCameraTransform;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
        missile = GetComponent<MissileBase>();
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit, shootingLayers))
        {
            Instantiate(bulletImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            flashParticle.Play();

            hit.collider.GetComponentInParent<DummyDamageHandler>()?.TakeDamage(missile);
        }
    }
}
