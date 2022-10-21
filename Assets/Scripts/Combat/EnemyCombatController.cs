using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    // sets the drops the enemy can drop
    public GameObject[] drops;

    // stats
    public float maxHealth; // max health
    public float currentHealth { get; private set; } // keeps current health private but displays in inspector
    public float resistance; // amount of resistance the enemy has
    public float damage; // amonut of damage the enemy does

    // Vector3 that offsets the drops from the ground
    public Vector3 offset = new Vector3(0, 1, 0);

    private int enemyDropIndex; // the integer that corresponds with the drop
    private int scoreModifier; // amount to increase score by

    private GameManager gameManager; // sets gamemanager
    private GameObject scoreText; // sets the score text game object

    private Spawner spawner; // sets the spawner object
    private PlayerCombatController playerCombatController; // sets the player combat controller

    private bool dead = false; // whether the enemy is dead or not
    private bool canAttack; // whether the enemy can attack or not
    
    // Start is called before the first frame update
    void Start()
    {
        // find objects
        gameManager = FindObjectOfType<GameManager>();
        scoreText = GameObject.FindGameObjectWithTag("Score");
        playerCombatController = FindObjectOfType<PlayerCombatController>();

        scoreModifier = gameManager.scoreModifier; // sets the score modifier
        currentHealth = maxHealth; // sets the current health to the max health
        enemyDropIndex = Random.Range(0, drops.Length); // gets a random value that corresponds to a drop
    }

    // called by other scripts
    // makes the enemy take damage by "damage" amount
    public void takeDamage(float damage)
    {
        // takes the enemies resistance away from the damage and clamps it to stay above 0
        damage -= resistance;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // takes away damage from current health
        currentHealth -= damage;

        // checks if the health is below or equal to 0 (dead)
        if (currentHealth <= 0)
        {
            gameManager.score += scoreModifier; // adds to score
            scoreText.GetComponent<ScoreManager>().UpdateScore(); // updates score

            // checks if the enemy is dead already (prevents running Die() multiple times)
            if (!dead)
            {
                Die();
            }
        }
    }

    // called when dead
    private void Die()
    {
        dead = true; // sets dead to true (prevents death from running multiple times)

        // spawn the random enemy drop
        Instantiate(drops[enemyDropIndex], transform.position + offset, drops[enemyDropIndex].transform.rotation); 
        Destroy(gameObject); // destroys enemy
    }

    // called by animation
    // attack player
    public void Attack()
    {
        // checks that the player has collided with the enemy
        if (canAttack)
        {
            // damages player
            playerCombatController.takeDamage(damage);
        }
    }

    // when an object triggers the collider enter
    // collider is the current game object (enemy)
    // other is the object that triggered the collider
    private void OnTriggerEnter(Collider other)
    {
        // checks if the player has collided
        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = true;
        }
    }
}
