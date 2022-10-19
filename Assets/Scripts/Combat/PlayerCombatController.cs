using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public int resistance;
    public int damage;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = gameManager.GetComponent<GameManager>().basePlayerHealth;
        damage = gameManager.GetComponent<GameManager>().basePlayerDamage;
        resistance = gameManager.GetComponent<GameManager>().basePlayerResistance;
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        damage *= 1 + (resistance/100);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

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
    }
}
