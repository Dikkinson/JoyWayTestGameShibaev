using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private KeyCode pickupKey;

    private Transform mainCameraTransform;

    private PickableObject currentPickedObject;
    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            currentPickedObject?.Drop();

            RaycastHit hit;
            if (Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit, pickupRange, pickupLayer))
            {
                currentPickedObject = hit.collider.GetComponent<PickableObject>();
                currentPickedObject.Pickup(transform);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Camera.main.transform.position, Camera.main.transform.position + new Vector3(0,0,pickupRange));
    }
}
