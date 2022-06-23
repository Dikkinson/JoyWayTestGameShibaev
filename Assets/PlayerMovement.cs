using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerMoveSpeed;
        moveDirection = transform.TransformVector(moveDirection);
        moveDirection = Vector3.ClampMagnitude(moveDirection, playerMoveSpeed);

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
