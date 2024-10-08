using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this to manage scenes

public class GameManager : MonoBehaviour
{
    public enum GameState { AttackPhase, ActionPhase, GameOver }
    public GameState currentState;

    private void Start()
    {
        // Start in Attack Phase
        currentState = GameState.AttackPhase;
        StartAttackPhase();
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.AttackPhase:
                HandleAttackPhase();
                break;

            case GameState.ActionPhase:
                HandleActionPhase();
                break;

            case GameState.GameOver:
                // Optionally handle Game Over state (e.g., stop gameplay)
                break;
        }
    }

    void StartAttackPhase()
    {
        // Logic for starting attack phase
        Debug.Log("Attack Phase Started");
    }

    void HandleAttackPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Example trigger
        {
            currentState = GameState.ActionPhase;
            StartActionPhase();
        }
    }

    void StartActionPhase()
    {
        // Logic for starting action phase
        Debug.Log("Action Phase Started");
    }

    void HandleActionPhase()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Example trigger to end action phase
        {
            currentState = GameState.AttackPhase;
            StartAttackPhase();
        }
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        Debug.Log("Game Over!");
        // Load Game Over scene
        SceneManager.LoadScene("game_over_secne"); // Replace with your Game Over scene name
    }
}
