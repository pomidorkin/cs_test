using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEventSubcriber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestEvent testEvent = GetComponent<TestEvent>();
        testEvent.OnSpacePressed += TestEvent_OnSpacePressed;
    }

    private void TestEvent_OnSpacePressed(object sender, TestEvent.OnSpacePressedEventArgs e)
    {
        Debug.Log("Space count: " + e.spaceCount);
        //Unsubcribing
        TestEvent testEvent = GetComponent<TestEvent>();
        testEvent.OnSpacePressed -= TestEvent_OnSpacePressed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
