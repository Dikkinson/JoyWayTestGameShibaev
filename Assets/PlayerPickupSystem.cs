using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupSystem : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private KeyCode leftHandPickupKey;
    [SerializeField] private KeyCode rightHandPickupKey;
    /*[SerializeField] private PlayerHand leftHand;
    [SerializeField] private PlayerHand rightHand;*/
    private Transform mainCameraTransform;
    
    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        
    }
}
