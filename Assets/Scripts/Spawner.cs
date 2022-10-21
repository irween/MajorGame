using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // setting the GameObject variables as a list
    public GameObject[] Enemies;

    // spawn range locations
    public float spawnRangeX1;
    public float spawnRangeX2;
    public float spawnRangeZ1;
    public float spawnRangeZ2;

    // the maximum value for random.range for enemy type
    public int spawnChanceSniper;

    private int enemyType; // enemy type - used to spawn different enemies
    private float spawnQuantity;

    // Start is called before the first frame update
    void Start()
    {
        // get spawn amount
        spawnQuantity = FindObjectOfType<GameManager>().spawnAmount;

        // the game starts by spawning enemies
        SpawnSniper();
        SpawnRandomEnemy();
    }

    // this function is called whenever there are no enemies, and at the start of the game
    // it spawns a random enemy type at a random location.
    // parameters - none
    // return value - none
    public void SpawnRandomEnemy()
    {
        // loops for length of spawn quantity (spawns that many times)
        for (int i = 0; i < spawnQuantity; i++)
        {
            // sets enemy type to random value from 0 to spawn chance sniper 
            enemyType = Random.Range(0, spawnChanceSniper);

            // checks if enemy type equals 1 
            if (enemyType == 1)
            {
                // spawns sniper enemy
                SpawnSniper();
            }
            else
            {
                // spawns normal enemy
                SpawnEnemy();
            }
        }
    }

    // spawns sniper
    public void SpawnSniper()
    {
        // gets random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2),
                1, Random.Range(spawnRangeZ1, spawnRangeZ2));
        
        // spawns sniper enemy at spawn pos
        Instantiate(Enemies[1], spawnPos, Enemies[1].transform.rotation);
    }

    // spawns normal enemy
    public void SpawnEnemy()
    {
        // gets random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2),
                1, Random.Range(spawnRangeZ1, spawnRangeZ2));

        // spawns normal enemy at spawn pos
        Instantiate(Enemies[0], spawnPos, Enemies[0].transform.rotation);
    }
}
