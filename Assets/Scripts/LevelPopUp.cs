using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class LevelPopUp : MonoBehaviour
{
    public Canvas levelCanvas; // Assign your tutorial Canvas in the Inspector
    public float autoCloseTime = 0f; // Set to > 0 for automatic closing after X seconds

    private bool isLevelActive = true;

    void Start()
    {
        // Ensure the tutorial canvas is active at the start
        if (levelCanvas != null)
        {
            levelCanvas.enabled = true;
        }

        // Auto-close the tutorial if autoCloseTime is set
        if (autoCloseTime > 0)
        {
            Invoke("CloseLevel", autoCloseTime);
        }
    }

    void Update()
    {
        if (isLevelActive)
        {
            // Close the tutorial if the player presses the trigger button
            InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed) && isPressed)
            {
                CloseLevel();
            }
        }
    }

    public void CloseLevel()
    {
        if (levelCanvas != null)
        {
            levelCanvas.enabled = false; // Hide the tutorial
        }
        isLevelActive = false; // Prevent further interaction
    }
}