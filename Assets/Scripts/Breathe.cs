using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Breathe : MonoBehaviour
{
    public AudioSource inhaleSound; // Reference to the "breath in" sound AudioSource
    public AudioSource exhaleSound; // Reference to the "breath out" sound AudioSource

    private bool wasTriggerPressed = false; // Tracks if the trigger was previously pressed
    private bool wasGripPressed = false; // Tracks if the grip was previously pressed

    void Update()
    {
        // Get the device for the right hand (use LeftHand for the left hand)
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        
        // Handle the trigger button for inhale
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isTriggerPressed))
        {
            if (isTriggerPressed && !wasTriggerPressed)
            {
                PlayInhaleSound();
            }

            // Update the previous state
            wasTriggerPressed = isTriggerPressed;
        }

        // Handle the grip button for exhale
        if (device.TryGetFeatureValue(CommonUsages.gripButton, out bool isGripPressed))
        {
            if (isGripPressed && !wasGripPressed)
            {
                PlayExhaleSound();
            }

            // Update the previous state
            wasGripPressed = isGripPressed;
        }
    }

    private void PlayInhaleSound()
    {
        if (inhaleSound != null && !inhaleSound.isPlaying)
        {
            inhaleSound.Play();
        }
    }

    private void PlayExhaleSound()
    {
        if (exhaleSound != null && !exhaleSound.isPlaying)
        {
            exhaleSound.Play();
        }
    }
}