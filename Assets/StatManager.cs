using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    private GameObject gameManager;

    public float basePlayerResistance;
    public float basePlayerHealth;
    public float basePlayerDamage;

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
            basePlayerResistance *= modifierPlayerResistance;
            basePlayerResistance = Mathf.RoundToInt(basePlayerResistance);
            gameManager.GetComponent<GameManager>().basePlayerResistance = basePlayerResistance;
        }

        if (stat == 2)
        {
            // increase damage
            basePlayerDamage *= modifierPlayerDamage;
            basePlayerDamage = Mathf.RoundToInt(basePlayerDamage);
            gameManager.GetComponent<GameManager>().basePlayerDamage = basePlayerDamage;
        }

        if (stat == 3)
        {
            // increase health
            basePlayerHealth *= modifierPlayerHealth;
            basePlayerHealth = Mathf.RoundToInt(basePlayerHealth);
            gameManager.GetComponent<GameManager>().basePlayerHealth = basePlayerHealth;
        }

        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
