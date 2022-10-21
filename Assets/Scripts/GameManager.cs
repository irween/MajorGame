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

    private UIManager uiManager;

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

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
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

    public void IncreaseBaseHealth(float health)
    {
        healthBar = FindObjectOfType<HealthBar>();

        basePlayerHealth += health;
        healthBar.SetMaxHealth((int)health);
    }

    public void AddToHealth(float health)
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, basePlayerHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void StartGame()
    {
        if (difficulty == 0)
        {
            basePlayerHealth *= 1.5f;
            basePlayerDamage *= 1.5f;
            basePlayerResistance *= 1.5f;

            baseSpawnAmount -= 5;
            scoreModifier /= 2;
        }
    }

    public void CompleteLevel()
    {
        if (currentWave == bossWave)
        {
            spawnAmount = baseSpawnAmount;
        }
        else
        {
            spawnAmount += levelSpawnAmountChange;
        }

        uiManager = FindObjectOfType<UIManager>();
        uiManager.CompleteLevel();
    }

    public void KillPlayer()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.KillPlayer();
    }
}
