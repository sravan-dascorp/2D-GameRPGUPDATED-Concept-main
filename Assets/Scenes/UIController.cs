using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public InputField InputField;
    public Button ButtonSendMesage;
    public Text MessageDisplay;
    private void Start()
    {
        ButtonSendMesage.onClick.AddListener(SendMessageUpdateRequest);
        EventController.OnMessageUpdateRequest += UpdateMessage;
    }
    void SendMessageUpdateRequest() 
    {
    // Store the input field's text into a string
    string message = InputField.text;

        EventController.Event_OnMessageUpdateRequest(message);
    }

    void UpdateMessage(string _message)
    {
        // Print the message
        Debug.LogFormat("-- UIController // Updating message: {0}", _message);

        // Replace our message display text with the contents of the message variable
        MessageDisplay.text = _message;

        // Reset the text of our input field
        InputField.text = "";
    }
}
