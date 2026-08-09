using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using System;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomLerpSpeed = 10f;
    [SerializeField] private float distance = 10f;

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

        //Camera = GetComponent<CinemachineCamera>;
    }

    private void ScrollClicked(InputAction.CallbackContext context)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
