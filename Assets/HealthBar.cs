using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        slider.maxValue = gameManager.basePlayerHealth;
        slider.value = gameManager.currentHealth;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
