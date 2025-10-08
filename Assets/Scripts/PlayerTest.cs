using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerTest : MonoBehaviour
{
    public Camera playerCamera;
    public float speed = 7f;
    public float jump = 8f;
    public float gravity = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float movementDirectionY = moveDirection.y;

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jump;

        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
