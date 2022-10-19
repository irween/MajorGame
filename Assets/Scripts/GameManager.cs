using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float difficulty;

    public GameObject completeLevelUI;
    public GameObject weaponUI;

    public int spawnAmount;
    public int levelSpawnChange;

    public int basePlayerResistance;
    public int basePlayerHealth;
    public int basePlayerDamage;
    
    public float modifierPlayerResistance;
    public float modifierPlayerHealth;
    public float modifierPlayerDamage;

    // 0 = empty
    // 1 = pistol
    // 2 = machine gun
    // 3 = shotgun
    public List<GameObject> weaponsListUI;

    void Start()
    {
        GameManager.Instance.difficulty = difficulty;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CompleteLevel()
    {
        spawnAmount += levelSpawnChange;
        Debug.Log("LEVEL COMPLETE");
        completeLevelUI.SetActive(true);
        weaponUI.SetActive(false);
    }

    public void KillPlayer()
    {

    }

    public void IncreaseStat(string stat)
    {
        if (stat == "resistance")
        {
            // increase resistance
            basePlayerResistance *= modifierPlayerResistance;
        }
        
        if (stat == "damage")
        {
            // increase resistance
            basePlayerDamage *= modifierPlayerDamage;
        }
        
        if (stat == "health")
        {
            // increase resistance
            basePlayerHealth*= modifierPlayerHealth;
        }
    }

    public void SetWeapon(string weapon)
    {
        if (weapon == "empty")
        {
            weaponsListUI[1].SetActive(false);
            weaponsListUI[3].SetActive(false);
            weaponsListUI[2].SetActive(false);
        }

        if (weapon == "pistol")
        {
            weaponsListUI[1].SetActive(true);
            weaponsListUI[2].SetActive(false);
            weaponsListUI[3].SetActive(false);
        }

        if (weapon == "machinegun")
        {
            weaponsListUI[2].SetActive(true);
            weaponsListUI[1].SetActive(false);
            weaponsListUI[3].SetActive(false);
        }

        if (weapon == "shotgun")
        {
            weaponsListUI[3].SetActive(true);
            weaponsListUI[1].SetActive(false);
            weaponsListUI[2].SetActive(false);
        }
    }
}
