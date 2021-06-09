using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    // Events are publishers to which we can add subcribers
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    // Specifying what args we want to pass to the subscribers
    public class OnSpacePressedEventArgs : EventArgs
    {
        public int spaceCount;
    }

    private int spaceCount;

    private void Testing_OnSpaceEvent(object sender, EventArgs e)
    {
        Debug.Log("Space pressed!");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Subcribing a function to the event
        OnSpacePressed += Testing_OnSpaceEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
        // Firing an event whenever the spacebar is pressed
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount}); // ?.Invoke syntaxis means if(object != null)
        }
    }
}
