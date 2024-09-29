using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandParser : MonoBehaviour
{
    public TMP_InputField inputField; // Link this in the inspector
    public Animator playerAnimator;   // Link the player's Animator in the inspector

    void Start()
    {
        inputField.onEndEdit.AddListener(ParseCommand); // Adds a listener to detect when input is submitted
    }

    void ParseCommand(string command)
    {
        // Clean the input to ensure it's lowercase and trimmed
        command = command.ToLower().Trim();

        switch (command)
        {
            case "punch":
                playerAnimator.SetBool("isPunch", true);  
                

                StartCoroutine(MoveCharacterForward(12.0f, 1.0f));
                StartCoroutine(ResetPunchBool());
                break;

            // Add more cases for other commands (e.g., "jump", "kick", etc.)
            default:
                Debug.Log("Unknown command");
                break;
        }

        // Clear the input field after processing
        inputField.text = "";
    }
    IEnumerator ResetPunchBool()
    {
        yield return new WaitForSeconds(1.5f); // Short delay before resetting (fine-tune as needed)
        playerAnimator.SetBool("isPunch", false);
    }
    IEnumerator MoveCharacterForward(float distance, float duration)
    {
        float elapsedTime = 0f;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();  // Ensure you have Rigidbody2D attached
        Vector2 startPosition = rb.position;
        Vector2 endPosition = rb.position + Vector2.left * distance;  // Move on x-axis

        while (elapsedTime < duration)
        {
            rb.MovePosition(Vector2.Lerp(startPosition, endPosition, elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait until the next frame
        }

        rb.MovePosition(endPosition);  // Ensure final position is reached
    }
}
