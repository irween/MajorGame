using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public int resistance = 0;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        damage -= resistance;
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
