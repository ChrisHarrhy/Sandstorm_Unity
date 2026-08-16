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

    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    void Update()
    {

    }
}

