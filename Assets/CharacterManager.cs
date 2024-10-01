using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array to hold the character prefabs

    private void Start()
    {
        // Get the selected character index from PlayerPrefs (default to 0 if not found)
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        // Instantiate the selected character at a specific position (e.g., Vector3.zero)
        Instantiate(characterPrefabs[selectedCharacterIndex], Vector3.zero, Quaternion.identity);
    }
}
