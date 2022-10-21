using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // sets slider
    public Slider slider;

    //sets gamemanager
    private GameManager gameManager;

    void Start()
    {
        // find gamemanager
        gameManager = FindObjectOfType<GameManager>();

        // set slider values
        slider.maxValue = gameManager.basePlayerHealth; // sets max slider value
        slider.value = gameManager.currentHealth; // sets current slider value
    }

    // called when updating max health
    // takes float for max health amount
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
    }

    // called when updating current health
    // takes float for current health amount
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
