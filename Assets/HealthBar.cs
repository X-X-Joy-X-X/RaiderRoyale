using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText; // Text for displaying health
    public float maxHealth = 100f;
    private float currentHealth;

    public float damagePerSecond = 20f; // Damage rate in health points per second

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        // Apply damage over time
        TakeDamage(damagePerSecond * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            HandleGameOver(); // Trigger game over when health reaches zero
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
        healthText.text = $"Health: {currentHealth}/{maxHealth}"; // Update health text
    }

    void HandleGameOver()
    {
        // Load the Game Over scene
        Debug.Log("Game Over! Loading Game Over Scene...");
        SceneManager.LoadScene("GameOverScene"); // Ensure this matches your scene name
    }
}