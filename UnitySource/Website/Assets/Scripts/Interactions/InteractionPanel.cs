using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionPanel : MonoBehaviour
{
    //panel childs
    public Image panelIcon;
    public TextMeshProUGUI panelObjectName;
    public TextMeshProUGUI panelDescription;

    //current interactable
    public static Interactable.InteractableObject interactableObject;

    void Start()
    {
        
    }

    void Update()
    {
        InteractListener();
    }

    private void OnEnable()
    {
        panelIcon.sprite = interactableObject.icon.sprite;
        panelObjectName.text = interactableObject.objectName;
        panelDescription.text = interactableObject.description;
    }

    void InteractListener()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(interactableObject.type == 0)
            {
                Application.OpenURL(interactableObject.url);
            }
            else
            {
                interactableObject.specialObject.SetActive(true);
            }
        }
    }
}
