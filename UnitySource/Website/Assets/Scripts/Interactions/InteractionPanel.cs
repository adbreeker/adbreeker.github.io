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
        panelIcon.sprite = interactableObject.icon.sprite;
        panelObjectName.text = interactableObject.objectName;
        panelDescription.text = interactableObject.description;

        InteractListener();
    }

    void InteractListener()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Application.OpenURL(interactableObject.url);
        }
    }
}
