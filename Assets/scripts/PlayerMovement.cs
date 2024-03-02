using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Apply movement
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Apply vertical velocity
        controller.Move(velocity * Time.deltaTime);
    }
}
