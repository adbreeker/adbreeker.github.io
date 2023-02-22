using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        url,
        special,
    };

    [Header("Interaction Object Setup")]
    public string objectName;
    [TextArea(5,20)]
    public string description = "";
    public Image icon;

    [Header("Interaction Type")]
    public InteractionType type;
    public string url = "";
    public GameObject specialObject;

    public InteractableObject interactableObject;

    private void Start()
    {
        interactableObject = new InteractableObject(objectName, description, icon, type, url, specialObject);
    }

    public struct InteractableObject
    {
        public string objectName;
        public string description;
        public Image icon;

        public InteractionType type;
        public string url;
        public GameObject specialObject;

        public InteractableObject(string objectName, string description, Image icon, InteractionType type, string url, GameObject specialObject)
        {
            this.objectName = objectName;
            this.description = description;
            this.icon = icon;

            this.type = type;
            this.url = url;
            this.specialObject = specialObject;
        }
    }
}


