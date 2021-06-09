using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate is a function signature and return type without any implementation
public class DelegateTest : MonoBehaviour
{

    // We specify the return type and the signature
    public delegate void TestDelegate();
    public delegate bool TestBoolDelegate(int i);

    // Making a field of the delegate
    // This field 'testDelegateFunction' can be assigned to a function
    // which matches the delegate signature
    private TestDelegate testDelegateFunction;
    private TestBoolDelegate testBoolDelegateFunction;

    // Built-in delegates

    // Avtion returns void and takes no parameters
    private Action testAction;
    // Ganaric action can take different parameters
    private Action<int, float> testGenericAction;
    // Fund has a return type. The last thing specified in the <> is the return type
    // Foe example: Func<int, int, bool> - this Func takes 2 ints and returns a bool
    private Func<bool> testFunc; // No parameters, bool return type
    private Func<int, bool> testParameterFunc; // takes an int as an argument, returns a bool

    void Start()
    {
        testDelegateFunction = MyTestDelegateFunction;
        testDelegateFunction += MySecondTestDelegateFunction;
        // testDelegateFunction = new TestDelegate(MySecondTestDelegateFunction); // Assigning explicitly

        // We cannot remove anonymous methods and lambdas from delegate, because there is no reference on them
        // so when we need to remove methods, it is better to make a proper function
        testDelegateFunction += delegate () { Debug.Log("Anonymous method"); }; // Anonymous method
        testDelegateFunction += () => { Debug.Log("Lambda expression"); }; // Lambda expression

        testDelegateFunction();
        testDelegateFunction -= MySecondTestDelegateFunction;
        testDelegateFunction();

        testBoolDelegateFunction = MyTestBoolFunction;
        // Lambda with arguments and return value
        testBoolDelegateFunction += (int i) => {
            Debug.Log(i < 5);
            return i < 5;
        };
        testBoolDelegateFunction(3);

        testGenericAction = (int i, float f) => { Debug.Log("Testing generic action"); };
        testGenericAction(1, 1.0f);
        testFunc = () => false;
        testFunc();
        testParameterFunc = (int i) => i == 1;
        testParameterFunc(1);
    }

    private void MyTestDelegateFunction()
    {
        Debug.Log("My Test Delegate Function");
    }

    private void MySecondTestDelegateFunction()
    {
        Debug.Log("My Second Test Delegate Function");
    }

    private bool MyTestBoolFunction(int i)
    {
        Debug.Log(i > 5);
        return i > 5;
    }

}
