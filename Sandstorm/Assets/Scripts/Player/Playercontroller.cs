using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement stats")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    private CharacterController characterController;
    private Vector3 moveInput;
    private Vector3 velocity;
    private bool isSprinting = false;

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundRadius = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;
    public float castDistance = 0.2f;

    [SerializeField] private Transform camTransform;
    [SerializeField] private bool shouldFaceDirection = false;

    [SerializeField] private bool sprintToggle = false; // Will later be in pause menu script

    // [SerializeField] private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpBufferCounter = jumpBufferTime;

            if (velocity.y > 0)
            {
                jumpBufferCounter = 0f;
            }
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (sprintToggle)
        {
            if (context.performed)
            {
                if (!isSprinting)
                {
                    isSprinting = true;
                    speed = 5f;
                }
                else
                {
                    isSprinting = false;
                    speed = 3f;
                }
            }
        }
        else
        {
            if (context.performed)
            {
                isSprinting = true;
                speed = 5f;
            }
            else if (context.canceled)
            {
                isSprinting = false;
                speed = 3f;
            }
        }
    }

    private void Update()
    {
        bool isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, castDistance, groundMask);

        if (jumpBufferCounter < 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (jumpBufferCounter > 0f && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpBufferCounter = 0f;
        }

        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * moveInput.y) + (right * moveInput.x);
        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (shouldFaceDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);

        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMovement = (moveDirection * speed) + velocity;
        characterController.Move(finalMovement * Time.deltaTime);
    }
}
