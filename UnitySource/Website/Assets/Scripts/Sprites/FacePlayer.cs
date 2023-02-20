using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform playerCamera;


    void Update()
    {
        transform.LookAt(playerCamera);
    }
}
