using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject commandsPanel; // Assign the "Commands" GameObject here
    public GameObject tutorialPanel; // Assign the "Tutorial" GameObject here

    private bool isShowingCommands = true;

    private void Start()
    {
        // Start with the Commands panel active and the Tutorial panel inactive
        commandsPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    private void Update()
    {
        // Replace "JoystickButton0" and "JoystickButton2" with the appropriate mappings for your VR controller
        // Button A to switch between texts
        if (Input.GetKeyDown(KeyCode.JoystickButton0)) // Button A (default)
        {
            TogglePanels();
        }

        // Button X to close the tutorial
        if (Input.GetKeyDown(KeyCode.JoystickButton2)) // Button X (default)
        {
            CloseTutorial();
        }
    }

    private void TogglePanels()
    {
        if (isShowingCommands)
        {
            // Switch to the Tutorial panel
            commandsPanel.SetActive(false);
            tutorialPanel.SetActive(true);
        }
        else
        {
            // Switch back to the Commands panel
            commandsPanel.SetActive(true);
            tutorialPanel.SetActive(false);
        }

        isShowingCommands = !isShowingCommands;
    }

    private void CloseTutorial()
    {
        // Disable both panels
        commandsPanel.SetActive(false);
        tutorialPanel.SetActive(false);
    }
}