using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    private Rigidbody playerRigidbody;
    private Vector3 moveDirection;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerMoveSpeed;
        moveDirection = transform.TransformVector(moveDirection);
        moveDirection = Vector3.ClampMagnitude(moveDirection, playerMoveSpeed);
    }

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * Time.fixedDeltaTime);
    }
}
