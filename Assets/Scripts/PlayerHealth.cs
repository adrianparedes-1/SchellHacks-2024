using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private TMP_Text healthText; // Reference to the UI Text

    private void Start() {
        health = maxHealth;
        UpdateHealthUI(); // Update UI at start
    }

    public void UpdateHealth(float mod) 
    {
        health += mod;

        if (health > maxHealth) {
            health = maxHealth;
        } else if (health <= 0) {
            health = 0f;
            SceneManager.LoadSceneAsync(3); // Load game over or similar scene
        }

        UpdateHealthUI(); // Update the UI whenever health changes
    }

    private void UpdateHealthUI()
    {
        if (healthText != null) {
            healthText.text = "Health: " + health.ToString("0"); // Display health as an integer
        }
    }
}

