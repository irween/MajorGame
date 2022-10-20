using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float resistance;
    public float playerDamage;

    public HealthBar healthBar;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        maxHealth = gameManager.GetComponent<GameManager>().basePlayerHealth;
        playerDamage = gameManager.GetComponent<GameManager>().basePlayerDamage;
        resistance = gameManager.GetComponent<GameManager>().basePlayerResistance;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage(float damage)
    {
        damage *= 1 + (resistance/100);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        damage = Mathf.RoundToInt(damage);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Debug.Log(transform.name + " took " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // death goes here
        // will be overwritten
        Debug.Log(transform.name + " died");
        gameManager.GetComponent<GameManager>().KillPlayer();
    }
}
