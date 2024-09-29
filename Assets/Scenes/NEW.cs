using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for accessing UI elements

public class CommandReader : MonoBehaviour
{
    public InputField InputField;  // Drag the InputField from the Inspector
    public Text outputText;        // Optional: A Text object to display responses

    void Start()
    {
        // Make sure the input field is cleared at the start
        InputField.text = "";

        // Add listener to detect when user submits text
        InputField.onEndEdit.AddListener(OnInputSubmit);
    }

    // This function is called when the user finishes typing and presses Enter or leaves the InputField
    void OnInputSubmit(string userInput)
    {
        // Process the command entered in the input field
        string command = userInput.ToLower().Trim();  // Convert to lower case and trim spaces

        // Check for some basic commands
        if (command == "-punch")
        {
            HandlePunchCommand();
        }
        else if (command == "-jump")
        {
            HandleJumpCommand();
        }
        else
        {
            // Optional: Show an error message if the command is unknown
            outputText.text = "Unknown command: " + command;
        }

        // Clear the input field after submission
        InputField.text = "";
    }

    void HandlePunchCommand()
    {
        // Handle the punch command (e.g., trigger punch animation)
        Debug.Log("Punch Command Executed");
        outputText.text = "You punched!";
    }

    void HandleJumpCommand()
    {
        // Handle the jump command (e.g., trigger jump animation)
        Debug.Log("Jump Command Executed");
        outputText.text = "You jumped!";
    }
}
