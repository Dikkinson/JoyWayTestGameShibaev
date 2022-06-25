using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStone : MonoBehaviour, IWeapon
{
    [SerializeField] private float throwForce;
    [SerializeField] private GameObject waterMissilePrefab;

    public void Shoot()
    {
        GameObject missile = Instantiate(waterMissilePrefab, transform.position, transform.rotation);
        Rigidbody missileRigidbody = missile.GetComponent<Rigidbody>();
        missileRigidbody.AddForce(missileRigidbody.transform.forward * throwForce, ForceMode.Impulse);
    }
}
