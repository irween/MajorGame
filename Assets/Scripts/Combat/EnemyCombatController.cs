using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    public GameObject[] drops;

    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float resistance = 0;
    public float damage;

    private int scoreModifier;

    public Vector3 offset = new Vector3(0, 1, 0);

    public int enemyDropIndex;

    private bool canAttack;

    private GameObject gameManager;

    private GameObject scoreText;

    private Spawner spawner;

    private PlayerCombatController playerCombatController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scoreText = GameObject.FindGameObjectWithTag("Score");
        playerCombatController = FindObjectOfType<PlayerCombatController>();

        scoreModifier = gameManager.GetComponent<GameManager>().scoreModifier;
        currentHealth = maxHealth;
        enemyDropIndex = Random.Range(0, drops.Length);
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
        Instantiate(drops[enemyDropIndex], transform.position + offset, drops[enemyDropIndex].transform.rotation);
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (canAttack)
        {
            playerCombatController.takeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            spawner = FindObjectOfType<Spawner>();

            if (transform.name == "SniperTower")
            {
                spawner.SpawnSniper();
            }
            else
            {
                spawner.SpawnEnemy();
            }
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = true;
        }
    }
}
