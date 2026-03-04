using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    new Rigidbody rigidbody;

    [SerializeField] float jumpPower = 200;
    [SerializeField] float jumpCheck = 1.1f;
    [SerializeField] float movmentSpeed = 1f;
    Vector3 movmentVector = Vector3.zero;
    Vector2 movmentInput = Vector2.zero;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputValue input)
    {
        var inputVal = input.Get<Vector2>();
        movmentInput = inputVal;


    }
    private void OnMovementStop(InputValue input)
    {
        if (IsGrounded())
            rigidbody.linearVelocity = Vector2.zero;

    }


    void OnJump(InputValue input)
    {
        if (IsGrounded())
        {
            rigidbody.AddForce(Vector3.up * jumpPower);
        }
    }

    bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, jumpCheck);


    // Update is called once per frame
    void Update()
    {
        if ((movmentInput.x != 0 || movmentInput.y != 0) && IsGrounded())
        {
            Vector3 movmentVector = Vector3.zero;
            movmentVector += transform.right * movmentInput.x;
            movmentVector += transform.forward * movmentInput.y;
            movmentVector.y = 0;

            movmentVector.Normalize();
            movmentVector *= movmentSpeed;

            if (rigidbody.linearVelocity.magnitude < movmentSpeed)
                rigidbody.linearVelocity += movmentVector * Time.fixedDeltaTime;


        }
    }
}
