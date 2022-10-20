using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    public GameObject[] ammo;

    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float resistance = 0;

    private int scoreModifier;

    public Vector3 offset = new Vector3(0, 1, 0);

    public int ammoIndex;

    private GameObject gameManager;

    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scoreText = GameObject.FindGameObjectWithTag("Score");
        scoreModifier = gameManager.GetComponent<GameManager>().scoreModifier;
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        damage -= resistance;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        Debug.Log(transform.name + " took " + damage + " damage");

        if (currentHealth <= 0)
        {
            gameManager.GetComponent<GameManager>().score += scoreModifier;
            scoreText.GetComponent<ScoreManager>().UpdateScore();
            Die();
        }
    }

    private void Die()
    {
        ammoIndex =  Random.Range(0, ammo.Length);
        Instantiate(ammo[ammoIndex], transform.position + offset, ammo[ammoIndex].transform.rotation);
        Destroy(gameObject);
        Debug.Log(transform.name + " died");
    }
}
