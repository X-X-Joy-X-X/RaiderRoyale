using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Needed for scene management

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMesh Pro text for the timer
    public float countdownTime = 120f; // Set the countdown time in seconds
    private float remainingTime;

    private void Start()
    {
        remainingTime = countdownTime; // Initialize remaining time
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Decrease remaining time
            UpdateTimerUI();
        }
        else
        {
            // Timer reached zero, trigger game over
            remainingTime = 0; // Ensure it doesn't go negative
            TimerEnded();
        }
    }

    void UpdateTimerUI()
    {
        string minutes = ((int)(remainingTime / 60)).ToString();
        string seconds = (remainingTime % 60).ToString("f1"); // Format seconds

        timerText.text = minutes + ":" + seconds; // Update the displayed text
    }

    void TimerEnded()
    {
        // Logic for when the timer ends
        Debug.Log("Timer Ended! Loading Game Over Scene...");
        SceneManager.LoadScene("GameOverScene"); // Ensure this matches your scene name
    }
}
