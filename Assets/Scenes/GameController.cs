using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GameController : MonoBehaviour
{
    // B11,B3,B4,B1
    public GameObject B11;
    public GameObject B3;
    public GameObject B4;
    public GameObject B1;
    Vector3[] locations;
    public Controls controls;
    public GameObject joystick;
    public GameObject trackball;
    public TMPro.TextMeshProUGUI debug;

    private void Start()
    {

        // enable control
        controls = new Controls();
        controls.Enable();

        // subscribe to the button click action
        controls.Core.B11.performed += OnButtonClick;
        controls.Core.B3.performed += OnButtonClick;
        controls.Core.B4.performed += OnButtonClick;
        controls.Core.B1.performed += OnButtonClick;
        controls.Core.JoystickX.performed += OnJoystickTriggered;
        controls.Core.JoystickY.performed += OnJoystickTriggered;
        controls.Core.Trackball.performed += OnTrackballTriggered;
    }


    void OnButtonClick(InputAction.CallbackContext context)
    {
        string buttonTriggered = context.action.name;
        debug.text = (context.ToString());
        switch (buttonTriggered)
        {
            case "B11":
                B11.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "B3":
                B3.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "B4":
                B4.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "B1":
                B1.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
        }

    }

    void OnJoystickTriggered(InputAction.CallbackContext context)
    {
        joystick.GetComponentInChildren<Animator>().Play("JoystickInteraction", 0);
        debug.text = (context.ToString());

    }
    void OnTrackballTriggered(InputAction.CallbackContext context)
    {
        trackball.GetComponentInChildren<Animator>().Play("TrackballInteraction", 0);
        debug.text = (context.ToString());

    }
}
