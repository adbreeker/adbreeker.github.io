using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    
    public Transform playerBody;
    public Transform playerHead;

    float xRotation = 0f;

    public float yRotation, zRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yRotation = transform.localRotation.eulerAngles.y;
        zRotation = transform.localRotation.eulerAngles.z;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if(xRotation >= 0f)
        {
            playerHead.transform.localRotation = Quaternion.Euler(0, -90, 0);
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, yRotation, zRotation);
            playerHead.transform.localRotation = Quaternion.Euler(0, -90, -xRotation);
        }

        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
