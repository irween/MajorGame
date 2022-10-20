using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    private GameObject gameManager;

    public float modifierPlayerResistance;
    public float modifierPlayerHealth;
    public float modifierPlayerDamage;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void IncreaseStat(int stat)
    {
        Debug.Log("Increasing " + stat);

        if (stat == 1)
        {
            // increase resistance
            gameManager.GetComponent<GameManager>().basePlayerResistance += modifierPlayerResistance;
        }

        if (stat == 2)
        {
            // increase damage
            gameManager.GetComponent<GameManager>().basePlayerDamage *= modifierPlayerDamage;
        }

        if (stat == 3)
        {
            // increase health
            gameManager.GetComponent<GameManager>().IncreaseBaseHealth(modifierPlayerHealth);
            gameManager.GetComponent<GameManager>().AddToHealth(modifierPlayerHealth);
        }

        if (gameManager.GetComponent<GameManager>().currentWave == gameManager.GetComponent<GameManager>().bossWave)
        {
            SceneManager.LoadScene("BossLevel");
        }
        else
        {
            currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
