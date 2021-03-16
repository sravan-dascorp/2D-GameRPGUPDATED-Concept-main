using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public delegate void OnMessageUpdateRequestDelegate(string _message);
    public static OnMessageUpdateRequestDelegate OnMessageUpdateRequest;
    // Start is called before the first frame update
    public static void Event_OnMessageUpdateRequest(string _message)
    {
        Debug.LogFormat("-- EventController // Received a request to update message: {0}", _message);

        OnMessageUpdateRequest(_message);
    }

    // Update is called once per frame

}
