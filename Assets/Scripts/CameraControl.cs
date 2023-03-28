using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera playerCamera;

    public bool inControl = false;
    public bool animate = true;

    public float cameraSpeed = 1;

    private void Update()
    {
        Vector3 newRotation = transform.rotation.eulerAngles;

        if (Input.GetMouseButton(1) && inControl && !animate)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            newRotation += new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"),0);
        } 
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (animate && !inControl)
        {
            newRotation += new Vector3(0,Time.deltaTime * 10,0);
        }

        if (animate || inControl)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(newRotation), cameraSpeed * Time.deltaTime);
        }
    }
}
