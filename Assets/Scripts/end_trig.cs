using UnityEngine;

public class end_trig : MonoBehaviour
{
    // sets gamemanager
    private GameManager gameManager;

    // amount of enemies in scene
    private int enemyCount;

    // when another object (other) collides with this (collider), enter
    void OnTriggerEnter(Collider other)
    {
        // checks if other object has player tag
        if (other.gameObject.CompareTag("Player"))
        {
            // finds all objects with enemy tag and gets the amount
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            // checks if the enemy count is 0
            if (enemyCount == 0)
            {
                // find gamemanager
                gameManager = FindObjectOfType<GameManager>();
                gameManager.CompleteLevel(); // trigger complete level function
            }
        }
    }
}
