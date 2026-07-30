using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{
    [Header("Movement stats")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    private CharacterController characterController;
    private Vector3 moveInput;
    private Vector3 velocity;
    private bool isJumping;

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundRadius = 0.3f;
    [SerializeField] private LayerMask groundMask;

    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }

    private void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundRadius, groundMask);

        Debug.Log(isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        if (isJumping)
        {
            if (isGrounded)
            {
                Debug.Log("Jumping");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            isJumping = false;
        }

        velocity.y += gravity * Time.deltaTime;


        Vector3 finalMovement = (move * speed) + velocity;
        characterController.Move(finalMovement * Time.deltaTime);
    }
}
