using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public float currentHealth;
    public float resistance;
    public float playerDamage;
    private float maxHealth;

    public HealthBar healthBar;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerDamage = gameManager.GetComponent<GameManager>().basePlayerDamage;
        resistance = gameManager.GetComponent<GameManager>().basePlayerResistance;
        healthBar = FindObjectOfType<HealthBar>();
        maxHealth = gameManager.basePlayerHealth;
    }

    public void takeDamage(float damage)
    {
        damage *= 1 + (resistance/100);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        damage = Mathf.RoundToInt(damage);
        gameManager.AddToHealth(-damage);
        currentHealth = gameManager.currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.KillPlayer();
    }
}
