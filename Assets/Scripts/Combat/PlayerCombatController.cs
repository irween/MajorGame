using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    // stats
    public float currentHealth;
    public float resistance;
    public float playerDamage;
    
    public HealthBar healthBar; // healthbar ui
    private float maxHealth;

    // sets gamemanager
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // find objects
        gameManager = FindObjectOfType<GameManager>();
        healthBar = FindObjectOfType<HealthBar>();

        // setting player stats
        playerDamage = gameManager.basePlayerDamage;
        resistance = gameManager.basePlayerResistance / 100;
        currentHealth = gameManager.basePlayerHealth;

        // sets max health to the base player health from gamemanager
        maxHealth = gameManager.basePlayerHealth;
    }

    // called whenever another script calls this
    // damage takes damage away from the current health
    public void takeDamage(float damage)
    {
        damage *= 1 + resistance; // multiplies damage by a percentage to negate some damage
        damage = Mathf.RoundToInt(damage); // rounds the damage taken to a whole number
        gameManager.AddToHealth(-damage); // removes damage from health in gamemanager
        currentHealth = gameManager.currentHealth; // sets currenthealth to gamemanager currenthealth

        // checks the if player health is less than or equal to 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ends game
    private void Die()
    {
        // finds gamemanager
        gameManager = FindObjectOfType<GameManager>();
        gameManager.KillPlayer(); // calls kill player function
    }
}
