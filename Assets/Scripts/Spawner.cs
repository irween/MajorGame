using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // setting the GameObject variables as a list
    public GameObject[] Enemies;

    // setting the spawning variables
    public float spawnRangeX1;
    public float spawnRangeX2;
    public float spawnRangeZ1;
    public float spawnRangeZ2;

    public float spawnQuantity;

    public int spawnChanceSniper;

    private int enemySniper;

    // making a public variable that can be "turned on" or "off" (making it true or false) to stop and start the spawning.
    // this helps me troubleshoot the game
    public bool spawning = true;

    // setting private variables
    private int enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        // the game starts by spawning an enemy
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2),
                1, Random.Range(spawnRangeZ1, spawnRangeZ2));

        Instantiate(Enemies[1], spawnPos, Enemies[enemyIndex].transform.rotation);
        SpawnRandomEnemy();
    }

    // this function is called whenever there are no enemies, and at the start of the game
    // it spawns a random enemy type at a random location.
    // parameters - none
    // return value - none

    public void SpawnRandomEnemy()
    {
        for (int i = 0; i < spawnQuantity - 1; i++)
        {
            enemySniper = Random.Range(0, spawnChanceSniper);

            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2),
                1, Random.Range(spawnRangeZ1, spawnRangeZ2));

            if (enemySniper == 1)
            {
                Instantiate(Enemies[1], spawnPos, Enemies[enemyIndex].transform.rotation);
            }
            else
            {
                Instantiate(Enemies[0], spawnPos, Enemies[enemyIndex].transform.rotation);
            }
        }
    }
}
