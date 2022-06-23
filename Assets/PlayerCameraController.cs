using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    private Transform mainCameraTransform;
    private float mouseAxisY;
    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseAxisX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseAxisX, 0);
        mouseAxisY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseAxisY = Mathf.Clamp(mouseAxisY, -90, 90);
        mainCameraTransform.localRotation = Quaternion.Euler(mouseAxisY, 0, 0);
    }
}
