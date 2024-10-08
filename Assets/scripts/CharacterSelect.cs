using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Import for scene management

public class CharacterSelect : MonoBehaviour
{
    public CharacterData[] characters; // Array for holding character data
    public Image characterImage; // Image to display hovered character
    public TextMeshProUGUI descriptionText; // Text to display character description

    // Method to handle hovering over a character
    public void OnCharacterHover(int index)
    {
        characterImage.sprite = characters[index].characterImage; // Update the character image
        descriptionText.text = characters[index].description; // Update the description text
    }

    // Method to handle when no longer hovering over a character
    public void OnCharacterExit()
    {
        characterImage.sprite = null; // Clear the character image
        descriptionText.text = ""; // Clear the description text
    }

    // Method to handle when a character is clicked
    public void OnCharacterClick(int index)
    {
        // Save the selected character index to PlayerPrefs
        PlayerPrefs.SetInt("SelectedCharacterIndex", index);

        // Optionally, log the character selection
        Debug.Log("Character Selected: " + characters[index].characterName);

        // Load the main game scene (SampleScene)
        SceneManager.LoadScene("SampleScene");
    }
}

[System.Serializable]
public class CharacterData
{
    public string characterName;   // Name of the character
    public string description;     // Description of the character
    public Sprite characterImage;  // Image of the character (for UI display)
}
