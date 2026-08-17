using System;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private float speedDampTime;

    private Animator animator;
    private CharacterController characterController;
    private PlayerController playerController;

    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int isGroundHash = Animator.StringToHash("isGrounded");
    private readonly int jumpTriggerHash = Animator.StringToHash("Jump");
    private readonly int crouchHash = Animator.StringToHash("Crouch");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        UpdateAnimatorParameters();
    }

    private void UpdateAnimatorParameters()
    {
        
    }
}
