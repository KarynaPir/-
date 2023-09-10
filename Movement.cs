using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
     public float jumpSpeed = 4f;
    Vector3 velocity; 
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= runSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            movement *= walkSpeed * 0.5f * Time.deltaTime;
            characterController.height = 1f;
        }
        else
        {
            movement *= walkSpeed * Time.deltaTime;
            characterController.height = 2f;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            velocity.y = jumpSpeed;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime; 

        movement = transform.TransformDirection(movement);
        characterController.Move(movement + velocity * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }
}