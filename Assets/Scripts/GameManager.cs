using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public int spawnAmount;
    public int levelSpawnChange;

    public float basePlayerResistance;
    public float basePlayerHealth;
    public float basePlayerDamage;

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

        if (difficulty == 0)
        {
            basePlayerHealth *= 1.5f;
            basePlayerDamage *= 1.5f;
            basePlayerResistance *= 1.5f;
        }
    }

    public void CompleteLevel()
    {
        spawnAmount += levelSpawnChange;
        Debug.Log("LEVEL COMPLETE");
        completeLevelUI.SetActive(true);
        weaponUI.SetActive(false);

        currentWave += 1;
    }

    public void KillPlayer()
    {
        gameOverUI.SetActive(true);
        weaponUI.SetActive(false);
    }
}
