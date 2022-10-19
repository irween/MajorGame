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

    public string emptyName;
    public string pistolName;
    public string machineGunName;
    public string shotgunName;

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

        weaponsListUI.Add(GameObject.Find(emptyName));
        weaponsListUI.Add(GameObject.Find(pistolName));
        weaponsListUI.Add(GameObject.Find(machineGunName));
        weaponsListUI.Add(GameObject.Find(shotgunName));
    }

    void Start()
    {
        for (int i = 0; i < weaponsListUI.Count; i++)
        {
            Debug.Log(weaponsListUI[i].name);
            weaponsListUI[i].SetActive(false);
        }
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
        for (int i = 0; i < weaponsListUI.Count; i++)
        {
            if (weaponsListUI[i].name == weapon)
            {
                weaponsListUI[i].SetActive(true);
            }
            else
            {
                weaponsListUI[i].SetActive(false);
            }
        }
    }
}
