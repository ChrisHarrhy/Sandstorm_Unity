using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement stats")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    private CharacterController characterController;

    private Vector2 moveInput; // Changed to Vector2 to match InputSystem
    private Vector3 velocity;
    private bool isSprinting = false;
    private bool isWalking = false;

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundRadius = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;
    public float castDistance = 0.2f;

    [SerializeField] private Transform camTransform;
    [SerializeField] private bool shouldFaceDirection = false;

    [SerializeField] private bool sprintToggle = false;
    [SerializeField] private bool walkToggle = false;

    public bool isGrounded { get; private set; } 

    private PlayerAnimations playerAnims;

    // Public property so your Animation script can easily read real-time target speed
    public float CurrentSpeed => moveInput.magnitude * speed;

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
                isSprinting = !isSprinting;
                speed = isSprinting ? 10f : 6f;
            }
        }
        else
        {
            if (context.performed)
            {
                isSprinting = true;
                speed = 10f;
            }
            else if (context.canceled)
            {
                isSprinting = false;
                speed = 6f;
            }
        }
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (walkToggle)
        {
            if (context.performed)
            {
                isWalking = !isWalking;
                speed = isWalking ? 3f : 6f;

                Debug.Log("Walk clicked");
            }
        }
        else
        {
            if (context.performed)
            {
                isWalking = true;
                speed = 2f;
                Debug.Log("Walk clicked");
            }
            else if (context.canceled)
            {
                isWalking = false;
                speed = 6f;
            }
        }
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, castDistance, groundMask);

        if (jumpBufferCounter > 0)
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

        // Camera relative direction calculation
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * moveInput.y) + (right * moveInput.x);

        if (shouldFaceDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }

        // Apply gravity to Y velocity
        velocity.y += gravity * Time.deltaTime;

        // Combine horizontal move direction with vertical velocity into ONE single move call
        Vector3 finalMovement = (moveDirection * speed) + velocity;
        characterController.Move(finalMovement * Time.deltaTime);

        Debug.Log(speed);
    }
}