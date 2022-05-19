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
    private Vector2 rotationValue;
    private bool sprinting;

    [SerializeField] private CharacterController Controller; //should be replaced with player.controller
    [SerializeField] private Rigidbody playerRigidbody; //should be replaced with entity.rigidbody
    [SerializeField] private Player player;
    [SerializeField] private float Speed;
    [SerializeField] private float SprintModifier;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Gravity;
    [SerializeField] private float TerminalVelocity;
    [SerializeField] private Transform PlayerCamera; //should be replaced with player.camera
    [SerializeField] private float Sensitivity;
    [SerializeField] private float MaxXRotation;
    [SerializeField] private float MinXRotation;


    private void Awake()
    {
        sprinting = false;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        //lock cursor when script is enabled again
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        //unlock cursor while script is disabled
        Cursor.lockState = CursorLockMode.None;
    }


    private void Update()
    {
        MovePlayer();

        RotatePlayer(rotationValue);

        if (Velocity.y > TerminalVelocity)
        {
            Velocity.y += Gravity * Time.deltaTime;
        }        
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);

        //Increase speed when sprinting
        if (sprinting)
        {
            MoveVector *= SprintModifier;
        }

        Controller.Move((MoveVector * Time.deltaTime * Speed) + (Velocity * Time.deltaTime));
    }

    private void OnTurning(InputValue value)
    {
        rotationValue = value.Get<Vector2>();
        rotationValue = rotationValue * Time.deltaTime;
    }

    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0, PlayerMouseInput.x * Sensitivity, 0);
        player.lookDirection.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);    
    }

    private void RotatePlayer(Vector2 rotation)
    {
        xRotation -= rotation.y * Sensitivity;
        xRotation = Mathf.Clamp(xRotation, MinXRotation, MaxXRotation);

        transform.Rotate(0, rotation.x * Sensitivity, 0);
        player.lookDirection.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);    
    }

    private void OnMovement(InputValue value)
    {
        Vector2 movementIn2D = value.Get<Vector2>();
        //Note that when going from 2D vector to 3D vector, the y in 2D becomes the z in 3D, Thanks Unity
        PlayerMovementInput = new Vector3(movementIn2D.x, 0, movementIn2D.y);
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
    }

    public void SetCameraTransform(Transform cameraTransform)
    {
        PlayerCamera = cameraTransform;
    }

    private void OnSprint(InputValue value)
    {
        sprinting = value.isPressed;
    }
}
