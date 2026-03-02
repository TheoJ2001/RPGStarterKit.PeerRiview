using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerLook : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] int mouseSensitivity = 1;
    float mouseX, mouseY;
    float yRotation, xRotation;

    void OnLook(InputValue input)
    {
        var inputVal = input.Get<Vector2>();
        mouseX = inputVal.x;
        mouseY = inputVal.y;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yRotation -= mouseY * mouseSensitivity * Time.deltaTime;
        xRotation += mouseX * mouseSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -35, 40);
        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
    }
}
