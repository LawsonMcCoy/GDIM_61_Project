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



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed);
        // PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // MoveCamera();
        MovePlayer();

        if (Controller.isGrounded)
        {
            Velocity.y -= Gravity * -2 * Time.deltaTime;
        }

    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        Debug.Log($"MoveVector: {PlayerMovementInput}");
        Controller.Move((MoveVector * Time.deltaTime * Speed) + (Velocity * Time.deltaTime));
        // Controller.Move(Velocity * Time.deltaTime);
    }

    private void OnTurning(InputValue value)
    {
        Vector2 rotationValue = value.Get<Vector2>();
        rotationValue = rotationValue * Time.deltaTime;
        // Debug.Log($"Turning: {rotationValue}");

        RotatePlayer(rotationValue);
    }

    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0, PlayerMouseInput.x * Sensitivity, 0);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);    
    }

    private void RotatePlayer(Vector2 rotation)
    {
        xRotation -= rotation.y * Sensitivity;

        transform.Rotate(0, rotation.x * Sensitivity, 0);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); 
    }

    private void OnMovement(InputValue value)
    {
        Vector2 movementIn2D = value.Get<Vector2>();
        //Note that when going from 2D vector to 3D vector, the y in 2D becomes the z in 3D, Thanks Unity
        PlayerMovementInput = new Vector3(movementIn2D.x, 0, movementIn2D.y);
        MovePlayer();
    } 

    private void OnJump(InputValue value)
    {
         if (Controller.isGrounded)
        {
            Velocity.y = -1;
            if (value.isPressed)
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y -= Gravity * -2 * Time.deltaTime;
        }
    }

    public void SetCameraTransform(Transform cameraTransform)
    {
        PlayerCamera = cameraTransform;
    }
}
