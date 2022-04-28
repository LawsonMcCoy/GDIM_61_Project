using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRotation;

    [SerializeField] private CharacterController Controller;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Gravity;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private float Sensitivity;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed);
        // PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // MoveCamera();
        MovePlayer();

    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        Controller.Move(MoveVector * Time.deltaTime);
        Controller.Move(Velocity * Time.deltaTime);
        // if (Controller.isGrounded)
        // {
        //     Velocity.y = -1;
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         Velocity.y = JumpForce;
        //     }
        // }
        // else
        // {
        //     Velocity.y -= Gravity * -2 * Time.deltaTime;
        // }
    }
    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0, PlayerMouseInput.x * Sensitivity, 0);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);    
    }

    private void OnMovement(InputValue value)
    {
        Vector2 movementIn2D = value.Get<Vector2>();
        //Note that when going from 2D vector to 3D vector, the y in 2D becomes the z in 3D, Thanks Unity
        PlayerMovementInput = new Vector3(movementIn2D.x, 0, movementIn2D.y);
        MovePlayer();
    } 

    private void OnJump()
    {
        Vector3 jumpVector
        playerRigidbody.AddForce()
    }
}
