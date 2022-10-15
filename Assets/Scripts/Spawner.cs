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


    // making a public variable that can be "turned on" or "off" (making it true or false) to stop and start the spawning.
    // this helps me troubleshoot the game
    public bool spawning = true;

    // setting private variables
    private int enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        // the game starts by spawning an enemy and a powerup
        SpawnRandomEnemy();
    }

    // this function is called whenever there are no enemies, and at the start of the game
    // it spawns a random enemy type at a random location.
    // parameters - none
    // return value - none

    public void SpawnRandomEnemy()
    {
        // getting a random index of the powerup list
        enemyIndex = Random.Range(0, Enemies.Length);

        // getting a random spawn location in the specefied range
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX1, spawnRangeX2),
            1, Random.Range(spawnRangeZ1, spawnRangeZ2));

        // spawning the enemy
        Instantiate(Enemies[enemyIndex], spawnPos, Enemies[enemyIndex].transform.rotation);

    }
}
