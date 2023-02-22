using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Net.Mail;
using TMPro;
using System.Text.RegularExpressions;

public class MailPanel : MonoBehaviour
{
    public TMP_InputField senderName, email, message;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void ButtonSend()
    {
        StartCoroutine("SendEmail");
    }

    public void ButtonClose()
    {
        senderName.text = "";
        email.text = "";
        message.text = "";
        gameObject.SetActive(false);
    }

    IEnumerator SendEmail()
    {
        // Validate the email address
        string emailTrimed = email.text.Trim(new char[] { ' ', '\t', '\n', '\r', '\u200B' });

        if (!IsValidEmail(emailTrimed))
        {
            Debug.LogError("Invalid email address.");
            yield break;
        }

        // Set the form data
        WWWForm form = new WWWForm();
        form.AddField("name", senderName.text);
        form.AddField("email", emailTrimed);
        form.AddField("message", message.text);

        // Set the URL of the formspree endpoint
        string url = "https://formspree.io/f/mbjeopyw";

        // Create a new UnityWebRequest object
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        // Set the headers to accept JSON data and disable caching
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("Cache-Control", "no-cache");

        // Send the request and wait for a response
        yield return www.SendWebRequest();

        // Check for errors
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error sending email: " + www.error);
            message.text = www.error;
        }
        else
        {
            Debug.Log("Email sent successfully!");
            senderName.text = "";
            email.text = "";
            message.text = "";

        }
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}

