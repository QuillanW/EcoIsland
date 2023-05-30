using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera playerCamera;

    public bool inControl = false;
    public bool animate = true;

    Vector3 wantedRotation;
    float scrollPosition = -80;

    public float cameraSpeed = 1;

    private void Start()
    {
        wantedRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (inControl && !animate)
        {
            //Camera zoom
            scrollPosition += Input.GetAxis("Scroll") * Time.deltaTime * 5000 * cameraSpeed;
            scrollPosition = Mathf.Clamp(scrollPosition,-80,-10);
            playerCamera.transform.localPosition = new Vector3(0, 0, scrollPosition);
        }

        if (Input.GetMouseButton(1) && inControl && !animate)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            wantedRotation += new Vector3(-Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime * cameraSpeed, Input.GetAxis("Mouse X") * 500 * Time.deltaTime * cameraSpeed, 0);
        } 
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (animate && !inControl)
        {
            wantedRotation += new Vector3(0, 10 * Time.deltaTime, 0);
        }

        if (animate || inControl)
        {
            //Limit camera rotation
            wantedRotation = new Vector3(Mathf.Clamp(wantedRotation.x,10,90),wantedRotation.y,0);
            //Set the rotation
            transform.rotation = Quaternion.Euler(wantedRotation);
        }
    }
}
