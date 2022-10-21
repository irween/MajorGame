using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    private GameManager gameManager;

    public float modifierPlayerResistance;
    public float modifierPlayerHealth;
    public float modifierPlayerDamage;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void IncreaseStat(int stat)
    {
        Debug.Log("Increasing " + stat);

        if (stat == 1)
        {
            // increase resistance
            gameManager.basePlayerResistance += modifierPlayerResistance;
        }

        if (stat == 2)
        {
            // increase damage
            gameManager.basePlayerDamage *= modifierPlayerDamage;
        }

        if (stat == 3)
        {
            // increase health
            gameManager.IncreaseBaseHealth(modifierPlayerHealth);
            gameManager.AddToHealth(modifierPlayerHealth);
        }

        if (gameManager.currentWave == gameManager.GetComponent<GameManager>().bossWave)
        {
            SceneManager.LoadScene("BossLevel");
        }
        else
        {
            gameManager.currentWave++;
            currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
