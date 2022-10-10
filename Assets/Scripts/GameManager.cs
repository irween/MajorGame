using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject weaponUI;

    private bool pistol = false;
    private bool machineGun = false;
    private bool shotgun = false;

    // 0 = empty
    // 1 = pistol
    // 2 = machine gun
    public List<GameObject> weaponsListUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompleteLevel()
    {
        Debug.Log("LEVEL COMPLETE");
        completeLevelUI.SetActive(true);
        weaponUI.SetActive(false);
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
