using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPointedObject : MonoBehaviour
{
    public LayerMask raycastIgonore;
    public float raycastRange;

    void Update()
    {
        RaycastHit lookingAt;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out lookingAt, raycastRange, ~raycastIgonore, QueryTriggerInteraction.Collide))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lookingAt.distance, Color.yellow);
            Debug.Log(lookingAt.collider.gameObject.name);
        }
    }
}
