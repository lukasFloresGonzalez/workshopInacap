using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    // Variables para movimiento de la cámara
    public Camera playerCamera;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;


    private void Update()
    {
        HandleCameraMovement();
    }

    
    private void HandleCameraMovement()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
