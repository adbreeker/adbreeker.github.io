using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float speed = 1;
    public float rotationRange = 45.0f;

    Vector3 startingRotation;
    bool increasing = true;
    float allowedRotationUp, allowedRotationDown;

    void Start()
    {
        startingRotation = transform.localRotation.eulerAngles;
        allowedRotationUp = startingRotation.y + rotationRange;
        allowedRotationDown = startingRotation.y - rotationRange;
    }

    void Update()
    {
        float currentRotationY = transform.localRotation.eulerAngles.y;

        if (increasing)
        {
            if(currentRotationY < allowedRotationUp)
            {
                float rotateY = currentRotationY + speed * Time.deltaTime;
                if(rotateY >= allowedRotationUp)
                {
                    increasing = false;
                }
                rotateY = Mathf.Clamp(rotateY, allowedRotationDown, allowedRotationUp);
                transform.localRotation = Quaternion.Euler(startingRotation.x, rotateY, startingRotation.x);
            }
            else
            {
                increasing = false;
            }

        }
        else
        {
            if (currentRotationY > allowedRotationDown)
            {
                float rotateY = currentRotationY - speed * Time.deltaTime;
                if (rotateY <= allowedRotationDown)
                {
                    increasing = true;
                }
                rotateY = Mathf.Clamp(rotateY, allowedRotationDown, allowedRotationUp);
                transform.localRotation = Quaternion.Euler(startingRotation.x, rotateY, startingRotation.x);
            }
            else
            {
                increasing = true;
            }

        }
    }
}
