using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//using UnityEngine;
//using UnityEngine.Events;

//public class EventManager : MonoBehaviour
//{
//    public UnityEvent myEvent;

//    void Start()
//    {
//        myEvent.Invoke();
//    }
//}

public class vrMagneticButtonScript : MonoBehaviour
{
    public enum InputEvent { multipleButtonPresses, LongHeldPress, Idle }
    public InputEvent inputEvent = InputEvent.Idle;
    public UnityEvent multiDoublePress;
    public UnityEvent externalTogglePauseFunction;


    public float t1=0;
    public float t2=0;
    float countdown1 = -1;
    float countdown2 = -1;
    public int noOfTimesButtonPressed = 0;
    public bool buttonIsDown=false;

    void Update()
    {

        float timeDifference = 1 * Time.deltaTime;
        if (countdown1 > 0)
        {
            countdown1 -= timeDifference;
        }

        if (countdown2 > 0)
        {
            countdown2 -= timeDifference;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            buttonIsDown = true;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            buttonIsDown = false;
        }

        if (buttonIsDown)
        {
            if (countdown1 == -1)
            {
                countdown1 = t1;
            }

            if (countdown1 <= 0 && countdown1 > -1)
            {
                inputEvent = InputEvent.LongHeldPress;
                callEventFunction(inputEvent);
                resetValues();
            }
        }
        else
        {
            if (countdown1 > 0)
            {
                if (countdown2 == -1)
                {
                    countdown1 = -1f;
                    countdown2 = t2;
                }
                if (countdown2 > 0)
                {
                    countdown1 = -1f;
                    noOfTimesButtonPressed += 1;
                }
            }

            if (countdown2 <= 0 && countdown2 > -1)
            {
                inputEvent = InputEvent.multipleButtonPresses;
                callEventFunction(inputEvent, noOfTimesButtonPressed);
                resetValues();
            }
        }

    }

    void resetValues()
    {
        countdown1 = -1f;
        countdown2 = -1f;
        noOfTimesButtonPressed = 0;
        inputEvent = InputEvent.Idle;
        buttonIsDown = false;
    }

    void callEventFunction(InputEvent eventType,int noOfPresses=0)
    {
        if (eventType==InputEvent.Idle)
        {
            return;
        }
        else if (eventType == InputEvent.LongHeldPress)
        {
            externalTogglePauseFunction.Invoke();
        }
        else
        {
            switch (noOfPresses)
            {
                case 1: break;
                case 2: multiDoublePress.Invoke(); break;
                case 3: break;
            }
        }
    }
}
