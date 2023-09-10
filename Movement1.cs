using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    CharacterController characterController;

    // Start викликається перед першим оновленням кадру
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update викликається кожного кадру
    void Update()
    {
        // Перемістити програвач на основі вводу
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement *= walkSpeed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);

        // Застосовуємо гравітацію до гравця
        characterController.Move(Physics.gravity * Time.deltaTime);
    }
}