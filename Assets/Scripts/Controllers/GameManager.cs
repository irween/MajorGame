using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // gamemanager instance
    public static GameManager Instance;

    // sets score and score modifier (how much the score increases)
    public int score;
    public int scoreModifier;

    // sets the difficulty
    public float difficulty;
    
    // spawner variables
    public int baseSpawnAmount; // the start amount of enemies to spawn (stays the same)
    public int levelSpawnAmountChange; // the amount that increases spawn amount (to spawn more enemies)
    public int spawnAmount; // the current amount of enemies to spawn

    // player variables
    public float basePlayerResistance; // the start amount of resistance the player has (changes)
    public float basePlayerHealth; // the start amount of health the player has (changes)
    public float basePlayerDamage; // the start amount of damage the player has (changes)
    
    public float startPlayerResistance; // the base amount of resistance the player has (stays the same)
    public float startPlayerHealth; // the base amount of health the player has (stays the same)
    public float startPlayerDamage; // the base amount of damage the player has (stays the same)
    public float currentHealth; // the current health the player has

    // wave variables
    public int bossWave; // the wave the boss level triggers
    public int currentWave; // the current wave
    public bool bossLevel = false; // if the boss level has started

    // ui variables
    private HealthBar healthBar; // the healthbar ui object
    private UIManager uiManager; // the ui manager

    private void Awake()
    {
        // checks if the instance has a value
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // instances this game object
        Instance = this; 

        // keep the gamemanager when the scene reloads rather than delete
        DontDestroyOnLoad(gameObject);

        // instances the difficulty of this object
        GameManager.Instance.difficulty = difficulty; 

        // finds the healthbar
        healthBar = FindObjectOfType<HealthBar>();

        // sets current health to the base player health
        currentHealth = basePlayerHealth;
    }

    void Start()
    {
        // sets the healthbar
        healthBar.SetMaxHealth(basePlayerHealth); // sets the max health of the health bar slider to the base player health
        healthBar.SetHealth(currentHealth); // sets the healthbar slider value to the current health

        // sets the spawn amount to the base spawn amount
        spawnAmount = baseSpawnAmount;
    }

    /// <summary>
    /// increases the base health of the player
    /// called whenever the player selects the increase health modifier
    /// health is the amount of max health the player gains
    /// </summary>
    /// <param name="health"></param>
    public void IncreaseBaseHealth(float health)
    {
        // finds the healthbar
        healthBar = FindObjectOfType<HealthBar>();

        // increases base player health by health
        basePlayerHealth += health;

        // sets the healthbar max value to h
        healthBar.SetMaxHealth((int)basePlayerHealth);
    }

    /// <summary>
    /// increases the current health of the player
    /// called whenever the player picks up a heart
    /// health is the amount of health to gain
    /// </summary>
    /// <param name="health"></param>
    public void AddToHealth(float health)
    {
        // finds the healthbar
        healthBar = FindObjectOfType<HealthBar>();

        // increases the current health 
        currentHealth += health;

        // clamps the current health to be between the max health (base player health)
        currentHealth = Mathf.Clamp(currentHealth, 0, basePlayerHealth);

        // sets the healthbar value to the current health
        healthBar.SetHealth(currentHealth);
    }

    // called when the player presses play on the menu screen
    // resets all the variables to their default values
    public void StartGame()
    {
        bossLevel = false; // sets boss level to false
        currentWave = 0; // sets the current wave to 0

        // sets the base player stats to their default values
        basePlayerResistance = startPlayerResistance;
        basePlayerHealth = startPlayerHealth;
        basePlayerDamage = startPlayerDamage;

        // checks if the difficulty is easy (0) and increases/decreases different values
        if (difficulty == 0)
        {
            // increases the player stats by 50%
            basePlayerHealth *= 1.5f;
            basePlayerDamage *= 1.5f;
            basePlayerResistance *= 1.5f;

            // sets the current health to the base player health (full health)
            currentHealth = basePlayerHealth;

            // sets the spawn amount to base spawn amount less 5
            spawnAmount = baseSpawnAmount - 5;

            // halves the score modifier
            scoreModifier /= 2;
        }
    }

    // called when the level is completed
    // changes spawn amount and checks if the boss level started
    public void CompleteLevel()
    {
        // checks if the current wave is equal to the boss wave
        if (currentWave == bossWave)
        {
            // changes spawn amount to the default amount + the level spawn amount modifier
            spawnAmount = baseSpawnAmount;

            // changes boss level to true
            bossLevel = true;
        }
        else
        {
            // increases spawn amount by the level spawn amount modifier
            spawnAmount += levelSpawnAmountChange;
        }

        // finds the ui manager
        uiManager = FindObjectOfType<UIManager>();
        // calls the complete level function in the ui manager
        uiManager.CompleteLevel();
    }

    // called when the player is killed
    public void KillPlayer()
    {
        // finds the ui manager
        uiManager = FindObjectOfType<UIManager>();
        // calls the kill player function in the ui manager
        uiManager.KillPlayer();
    }
}
