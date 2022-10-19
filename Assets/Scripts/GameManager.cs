using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float difficulty;

    public GameObject completeLevelUI;
    public GameObject weaponUI;

    public int spawnAmount;
    public int levelSpawnChange;

    public float basePlayerResistance;
    public float basePlayerHealth;
    public float basePlayerDamage;

    // 0 = empty
    // 1 = pistol
    // 2 = machine gun
    // 3 = shotgun
    public List<GameObject> weaponsListUI;

    private List<GameObject> weaponList;

    void Start()
    {
        GameManager.Instance.difficulty = difficulty;

        for (int i = 0; i < weaponsListUI.Count; i++)
        {
            weaponList.AddRange<weaponsListUI[i]>;
        }
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
