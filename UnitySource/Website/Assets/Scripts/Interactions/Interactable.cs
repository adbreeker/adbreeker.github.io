using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public string objectName;
    public string url;
    public string description = "";
    public Image icon;

    public InteractableObject interactableObject;

    private void Start()
    {
        interactableObject = new InteractableObject(objectName, url, description, icon);
    }

    public struct InteractableObject
    {
        public string objectName;
        public string url;
        public string description;
        public Image icon;

        public InteractableObject(string objectName, string url, string description, Image icon)
        {
            this.objectName = objectName;
            this.url = url;
            this.description = description;
            this.icon = icon;
        }
    }
}


