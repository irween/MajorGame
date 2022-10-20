using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameManager gameManager;
    private HealthBar healthBar;
    public float healthToAdd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthBar = FindObjectOfType<HealthBar>();
            gameManager = FindObjectOfType<GameManager>();
            gameManager.AddToHealth(healthToAdd);
            healthBar.SetHealth(gameManager.currentHealth);
            Destroy(gameObject);
        }
    }
}