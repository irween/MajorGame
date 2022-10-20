using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public List<GameObject> weaponsListUI;

    public string emptyName;
    public string pistolName;
    public string machineGunName;
    public string shotgunName;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < weaponsListUI.Count; i++)
        {
            Debug.Log(weaponsListUI[i].name);
            weaponsListUI[i].SetActive(false);
        }
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
