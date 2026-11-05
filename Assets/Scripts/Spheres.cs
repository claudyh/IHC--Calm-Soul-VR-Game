using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    // Variables - - -
    public Transform player;
    public float speed = 1f;
    public bool isInhaleOrb = true;
    private bool hasCollided = false;
    //private Inventory inventory;
    private bool isAttracting = false;

    public Slider progressBar;
    private float currentHoldTime = 0f;
    public float holdTime = 2f;

    private Canvas progressBarCanvas;
    public AudioSource collectSound;

    
    // Initiate player - - -
    void Start()
    {
        //inventory = other.GetComponent<Inventory>();

        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            this.player = player.transform;
        }

        // Get the canvas component of the progress bar
        progressBarCanvas = progressBar.GetComponentInParent<Canvas>();
        if (progressBarCanvas != null)
        {
            progressBarCanvas.enabled = false; // Start disabled
        }
    }

    // Check if colliders touched - - -
    private void OnTriggerEnter(Collider other)
    {
        hasCollided = true;
        if (progressBarCanvas != null)
        {
            progressBarCanvas.enabled = true; // Show the progress bar
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasCollided = false;
        ResetProgressBar(); // Reset progress bar and related variables
        if (progressBarCanvas != null)
        {
            progressBarCanvas.enabled = false; // Hide the progress bar
        }
    }

    private void ResetProgressBar()
    {
        currentHoldTime = 0f;
        progressBar.value = 0f;
        isAttracting = false;
    }

    // Check if buttons are pressed - - -
    void Update()
    {
        if (hasCollided)
        {
            bool isButtonPressed = false;

            if (isInhaleOrb) // Yellow spheres
            {
                // Check Trigger Button (inhale)
                isButtonPressed = CheckButtonPress(CommonUsages.triggerButton);
            }
            else // Blue spheres
            {
                // Check Grip Button (exhale)
                isButtonPressed = CheckButtonPress(CommonUsages.gripButton);
            }


            if (isButtonPressed)
            {
                // Increment hold time
                currentHoldTime += Time.deltaTime;

                // Update the progress bar
                progressBar.value = Mathf.Clamp01(currentHoldTime / holdTime);

                // Start attracting if the progress bar is full
                if (currentHoldTime >= holdTime)
                {
                    isAttracting = true;
                    hasCollided = false;
                }
            }
            else if (!isAttracting)
            {
                ResetProgressBar(); // Reset if the button is released prematurely
            }
            else
            {
                // Reset hold time and progress bar if the button is released
                currentHoldTime = 0f;
                progressBar.value = 0f;
                isAttracting = false;
            }
        }

        if(isAttracting)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (!isAttracting) return;
        
        // Calculate a target position that ignores the Y-axis
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        // Move the sphere towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            
            if(collectSound != null)
            {
                collectSound.Play();
            }

            //inventory.SphereCollected();
            gameObject.SetActive(false);
            isAttracting = false;
        }
    }

    private bool CheckButtonPress(InputFeatureUsage<bool> button)
    {
        // Get XR input device (right or left hand)
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand); // Change to LeftHand for left hand
        if (device.TryGetFeatureValue(button, out bool isPressed))
        {
            return isPressed;
        }
        return false;
    }
}