using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private float speedDampTime;

    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int isGroundHash = Animator.StringToHash("isGrounded");
    private readonly int jumpTriggerHash = Animator.StringToHash("Jump");
    private readonly int crouchHash = Animator.StringToHash("Crouch");

    private Animator animator;
    private CharacterController characterController;
    private PlayerController playerController;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        float targetSpeed = playerController.CurrentSpeed;

        animator.SetFloat(speedHash, targetSpeed, 0.1f, Time.deltaTime);

        animator.SetBool(isGroundHash, playerController.isGrounded);
    }

    public void JumpAnim()
    {
        animator.SetTrigger(jumpTriggerHash);
    }
}
