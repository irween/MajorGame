using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    // setting the different stat modifiers (amount multiplied or added to the original stat)
    public float modifierPlayerResistance; // sets the resistance modifier (amount to increase resistance by)
    public float modifierPlayerHealth; // sets the health modifier (amount to increase health by)
    public float modifierPlayerDamage; // sets the damage modifier (amount to increase damage by)

    // setting current scene and gamemanager variables
    private Scene currentScene;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // finds the gamemanager
        gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// this function increases the stat by a certain amount when called by other scripts/objects
    /// 
    /// the int, stat, is corresponds to the specific stat that is going to be increased ie 1 = resistance 2 = damage and 3 = health
    /// </summary>
    /// <param name="stat"></param>
    public void IncreaseStat(int stat)
    {
        // checking what stat is going to be updated
        if (stat == 1) // if stat 1 (resistance)
        {
            // increase resistance by resistance modifier
            gameManager.basePlayerResistance += modifierPlayerResistance;
        }

        if (stat == 2) // if stat 2 (damage)
        {
            // increase damage by damage modifier
            gameManager.basePlayerDamage *= modifierPlayerDamage;
        }

        if (stat == 3) // if stat 3 (health)
        {
            // increase health by health modifier 
            gameManager.IncreaseBaseHealth(modifierPlayerHealth);
            gameManager.AddToHealth(modifierPlayerHealth);
        }

        // checking if the scene should switch to the boss scene
        if (gameManager.currentWave == gameManager.GetComponent<GameManager>().bossWave)
        {
            // load boss scene
            SceneManager.LoadScene("BossLevel");
        }
        else
        {
            // add to the current wave and reload current scene
            gameManager.currentWave++;
            currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
