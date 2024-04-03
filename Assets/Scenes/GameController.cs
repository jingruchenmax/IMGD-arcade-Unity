using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GameController : MonoBehaviour
{
    // B11,B2,B0,B1
    public GameObject[] Buttons;
    Vector3[] locations;
    public Controls controls;
    public GameObject joystick;
    public GameObject traceball;
    public TMPro.TextMeshProUGUI debug;

    private void Start()
    {
        // initate locations and location index
        locations = new Vector3[4];
        for(int i = 0; i < Buttons.Length; i++)
        {
            locations[i] = Buttons[i].transform.position;
        }

        // enable control
        controls = new Controls();
        controls.Enable();

        // subscribe to the button click action
        controls.Core.B4.performed += OnButtonClick;
        controls.Core.B1.performed += OnButtonClick;
        controls.Core.B2.performed += OnButtonClick;
        controls.Core.B11.performed += OnButtonClick;
        controls.Core.JoystickX.performed += OnJoystickTriggered;
        controls.Core.JoystickY.performed += OnJoystickTriggered;
        controls.Core.Traceball.performed += OnTraceballTriggered;
    }


    void OnButtonClick(InputAction.CallbackContext context)
    {
        string buttonTriggered = context.action.name;
        debug.text = (context.ToString());
        switch (buttonTriggered)
        {
            case "B11":
                Buttons[0].GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "B4":
                Buttons[1].GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "B1":
                Buttons[2].GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "B2":
                Buttons[3].GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
        }

    }

    void OnJoystickTriggered(InputAction.CallbackContext context)
    {
        joystick.GetComponentInChildren<Animator>().Play("JoystickInteraction", 0);
        debug.text = (context.ToString());

    }
    void OnTraceballTriggered(InputAction.CallbackContext context)
    {
        traceball.GetComponentInChildren<Animator>().Play("TraceballInteraction", 0);
        debug.text = (context.ToString());

    }
}
