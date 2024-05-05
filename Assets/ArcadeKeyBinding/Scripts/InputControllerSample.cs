using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InputControllerSample : MonoBehaviour
{
    // Home,J,K,L
    public GameObject Home, J, K, L; // Indicators
    public ArcadeControl arcadeControl; // ArcadeControl class generated from controller mapping
    public GameObject joystick;
    public GameObject trackball;
    public TMPro.TextMeshProUGUI debug;

    private void Start()
    {
        // enable control
        arcadeControl = new ArcadeControl();
        arcadeControl.Enable();

        // subscribe to the button click action
        arcadeControl.Core.Home.performed += OnButtonClick;
        arcadeControl.Core.J.performed += OnButtonClick;
        arcadeControl.Core.K.performed += OnButtonClick;
        arcadeControl.Core.L.performed += OnButtonClick;
        arcadeControl.Core.JoystickX.performed += OnJoystickTriggered;
        arcadeControl.Core.JoystickY.performed += OnJoystickTriggered;
        arcadeControl.Core.Trackball.performed += OnTrackballTriggered;
    }


    void OnButtonClick(InputAction.CallbackContext context)
    {
        string buttonTriggered = context.action.name;
        UpdateDebugText(context);
        switch (buttonTriggered)
        {
            case "Home":
                Home.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "J":
                J.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "K":
                K.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
            case "L":
                L.GetComponent<Animator>().Play("ButtonAnimation", 0);
                break;
        }
    }

    void OnJoystickTriggered(InputAction.CallbackContext context)
    {
        joystick.GetComponentInChildren<Animator>().Play("JoystickInteraction", 0);
        UpdateDebugText(context);
    }
    
    void OnTrackballTriggered(InputAction.CallbackContext context)
    {
        trackball.GetComponentInChildren<Animator>().Play("TrackballInteraction", 0);
        UpdateDebugText(context);
    }

    void UpdateDebugText(InputAction.CallbackContext context) {

        debug.text = $"IsArcadeMachine: {ArcadeDetector.IsArcadeMachine}\nInputCallbackContext: {context}";
    }
}
