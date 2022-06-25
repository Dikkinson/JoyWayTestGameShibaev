using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandPickUp : MonoBehaviour
{
    [SerializeField] private float pickUpRange;
    [SerializeField] private LayerMask pickableLayers;
    [SerializeField] private KeyCode pickUpKey;

    private Transform mainCameraTransform;

    private PickableObject currentPickedObject;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(pickUpKey))
        {
            EmptyHand();

            RaycastHit hit;
            Ray ray = new Ray(mainCameraTransform.position, mainCameraTransform.forward);
            if (Physics.Raycast(ray, out hit, pickUpRange, pickableLayers))
            {
                currentPickedObject = hit.collider.GetComponent<PickableObject>();
                currentPickedObject?.PickUpItem(transform);
            }
        }
    }

    public void EmptyHand()
    {
        currentPickedObject?.DropItem();
        currentPickedObject = null;
    }

    public IWeapon GetCurrentWeapon()
    {
        return currentPickedObject?.GetComponent<IWeapon>();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 cameraPosition = Camera.main.transform.position;
        Gizmos.DrawLine(cameraPosition, cameraPosition + new Vector3(0, 0, pickUpRange));
    }
#endif
}
