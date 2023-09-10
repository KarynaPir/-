using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerTransform;
    private float xRotation = 0f;

    // Start викликається перед першим оновленням кадру
    void Start()
    {
        // Приховуємо курсор миші
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update викликається кожного кадру
    void Update()
    {
        // Отримуємо дані за допомогою руху миші по осям X та Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // Повертаємо гравця горизонтально
        playerTransform.Rotate(Vector3.up * mouseX);

        // Повертаємо камеру вертикально
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
