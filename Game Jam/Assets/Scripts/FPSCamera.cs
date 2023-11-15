using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float xRotation = 0;
    public float lookSpeed = 1;
    public float lookSpeedX = 100;

    public Transform Player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY * lookSpeed;

        // min = -100, max = 60
        xRotation = Mathf.Clamp(xRotation, -100, 60);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        float yRotation = mouseX * lookSpeedX * Time.deltaTime;
        Player.Rotate(Vector3.up * yRotation);
    }
}
