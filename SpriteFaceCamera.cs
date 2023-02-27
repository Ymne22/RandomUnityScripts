using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFaceCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Get a reference to the main camera
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        // Make the sprite always face the camera
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }
}