using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using System;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomLerpSpeed = 10f;
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 15f;

    private PlayerControls controls;
    private CinemachineOrbitalFollow orbital;
    private CinemachineBrain brain;

    private float targetZoom;
    private float currentZoom;

    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Zoomcamera.performed += ScrollClicked;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ScrollClicked(InputAction.CallbackContext context)
    {
        float isPressed = context.ReadValue<float>();

        ToggleZoom();
    }

    void Update()
    {

    }

    void ToggleZoom()
    {
        if (controls != null)
        {
            Debug.Log("Nothing input connected");

            float zoomDelta = controls.Player.Zoomcamera.ReadValue<float>();

            targetZoom = Mathf.Clamp(orbital.Radius - zoomDelta * zoomSpeed, minDistance, maxDistance);

            orbital.Radius = currentZoom;
        }
    }
}

