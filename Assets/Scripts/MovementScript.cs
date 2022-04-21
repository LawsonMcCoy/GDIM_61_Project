using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;

    [SerializeField] private CharacterController Controller;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Gravity;

    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        MovePlayer();

    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        Controller.Move(MoveVector * Time.deltaTime);
        Controller.Move(Velocity * Time.deltaTime);
        if (Controller.isGrounded)
        {
            Velocity.y = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y -= Gravity * -2 * Time.deltaTime;
        }
    }
}
