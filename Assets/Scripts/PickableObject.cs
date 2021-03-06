using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void PickUpItem(Transform handTransform)
    {
        objectRigidbody.isKinematic = true;
        transform.position = handTransform.position;
        transform.rotation = handTransform.rotation;
        transform.parent = handTransform;
    }

    public void DropItem()
    {
        objectRigidbody.isKinematic = false;
        transform.parent = null;
    }
}
