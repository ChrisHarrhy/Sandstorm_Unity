using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{
    [Header("Movement stats")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 velocity;
    private bool isJumping;

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundRadius = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;
    public float castDistance = 0.2f;

    [SerializeField] private Transform cameraTransform;

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

    private void Update()
    {
        bool isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, castDistance, groundMask);

        if(jumpBufferCounter < 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (jumpBufferCounter > 0f && isGrounded)
        {
            Debug.Log("Jumping");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpBufferCounter = 0f;
        }

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMovement = (move * speed) + velocity;
        characterController.Move(finalMovement * Time.deltaTime);

        Vector3 forward = cameraTransform.forward; ;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * moveInput.y) + (right * moveInput.x);

        if(moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
