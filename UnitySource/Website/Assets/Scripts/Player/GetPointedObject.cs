using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPointedObject : MonoBehaviour
{
    public LayerMask raycastIgonore;
    public float raycastRange;

    [Header("Interaction panel")]
    public GameObject interactionPanel;

    void Update()
    {
        RaycastHit lookingAt;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out lookingAt, raycastRange, ~raycastIgonore, QueryTriggerInteraction.Collide))
        {
            Interactable potentialInteractable;
            if(lookingAt.collider.gameObject.TryGetComponent<Interactable>(out potentialInteractable))
            {
                Debug.Log("Patrze na interactable");
                InteractionPanel.interactableObject = potentialInteractable.interactableObject;
                interactionPanel.SetActive(true);
            }
            else
            {
                interactionPanel.SetActive(false);
            }
        }
        else
        {
            interactionPanel.SetActive(false);
        }
    }
}
