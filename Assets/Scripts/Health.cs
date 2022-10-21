using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // amount of health to add
    public float healthToAdd;

    // sets objects
    private GameManager gameManager;
    private HealthBar healthBar;

    // when another object (other) collides with this (collider), enter
    private void OnTriggerEnter(Collider other)
    {
        // checks if other object has the player tag
        if (other.gameObject.CompareTag("Player"))
        {
            // find objects
            healthBar = FindObjectOfType<HealthBar>();
            gameManager = FindObjectOfType<GameManager>();

            gameManager.AddToHealth(healthToAdd); // add to gamemanager current health
            healthBar.SetHealth(gameManager.currentHealth); // set the healthbar to gamemanager current health
            Destroy(gameObject);
        }
    }
}