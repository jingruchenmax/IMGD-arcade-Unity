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

    private void Awake()
    {
        arcadeControl = new ArcadeControl();
        arcadeControl.Enable();

        if (ArcadeDetector.IsArcadeMachine)
        {
            arcadeControl.PC.Disable();
            arcadeControl.Arcade.Enable();
        }
        else
        {
            arcadeControl.PC.Enable();
            arcadeControl.Arcade.Disable();
        }

        // subscribe to the button click action
        arcadeControl.PC.Home.performed += OnButtonClick;
        arcadeControl.PC.J.performed += OnButtonClick;
        arcadeControl.PC.K.performed += OnButtonClick;
        arcadeControl.PC.L.performed += OnButtonClick;
        arcadeControl.PC.JoystickX.performed += OnJoystickTriggered;
        arcadeControl.PC.JoystickY.performed += OnJoystickTriggered;
        arcadeControl.PC.Trackball.performed += OnTrackballTriggered;

        arcadeControl.Arcade.Home.performed += OnButtonClick;
        arcadeControl.Arcade.J.performed += OnButtonClick;
        arcadeControl.Arcade.K.performed += OnButtonClick;
        arcadeControl.Arcade.L.performed += OnButtonClick;
        arcadeControl.Arcade.JoystickX.performed += OnJoystickTriggered;
        arcadeControl.Arcade.JoystickY.performed += OnJoystickTriggered;
        arcadeControl.Arcade.Trackball.performed += OnTrackballTriggered;
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
