using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    private Transform mainCameraTransform;
    private Vector2 mouseAxis;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseAxis.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseAxis.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseAxis.x, 0);

        mouseAxis.y = Mathf.Clamp(mouseAxis.y, -90, 90);
        mainCameraTransform.localRotation = Quaternion.Euler(mouseAxis.y, 0, 0);
    }
}
