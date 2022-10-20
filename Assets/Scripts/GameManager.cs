using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    public int scoreModifier;

    public float difficulty;

    public GameObject completeLevelUI;
    public GameObject weaponUI;
    
    public GameObject gameOverUI;

    public int baseSpawnAmount;
    public int levelSpawnAmountChange;
    public int spawnAmount;

    public float basePlayerResistance;
    public float basePlayerHealth;
    public float basePlayerDamage;
    public float currentHealth;

    private HealthBar healthBar;

    public int bossWave;
    public int currentWave;

    private PlayerCombatController playerCombatController;

    private void Awake()
    {
        gameOverUI = GameObject.Find("GameOver");
        gameOverUI.SetActive(false);
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (difficulty == 0)
        {
            basePlayerHealth *= 1.5f;
            basePlayerDamage *= 1.5f;
            basePlayerResistance *= 1.5f;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        GameManager.Instance.difficulty = difficulty;

        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = basePlayerHealth;
    }
    void Start()
    {
        healthBar.SetMaxHealth(basePlayerHealth);
        healthBar.SetHealth(currentHealth);
        spawnAmount = baseSpawnAmount;

        Debug.Log(currentHealth);
    }

    public void AddToHealth(float health)
    {
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, basePlayerHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void CompleteLevel()
    {
        completeLevelUI = GameObject.FindGameObjectWithTag("LevelComplete");
        weaponUI = GameObject.FindGameObjectWithTag("WeaponUI");
        Debug.Log("LEVEL COMPLETE");
        completeLevelUI.SetActive(true);
        weaponUI.SetActive(false);
        currentWave += 1;
        if (currentWave == bossWave)
        {
            spawnAmount = baseSpawnAmount;
        }
        else
        {
            spawnAmount += levelSpawnAmountChange;
        }
    }

    public void KillPlayer()
    {
        gameOverUI = GameObject.Find("GameOver");
        weaponUI = GameObject.Find("WeaponUI");
        gameOverUI.SetActive(true);
        weaponUI.SetActive(false);
    }
}
