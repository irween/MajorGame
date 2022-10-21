using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    // list of weapon ui
    public List<GameObject> weaponsListUI;

    // weapon names
    public string emptyName;
    public string pistolName;
    public string machineGunName;
    public string shotgunName;

    // Start is called before the first frame update
    void Start()
    {
        // set each weapon to inactive
        for (int i = 0; i < weaponsListUI.Count; i++)
        {
            weaponsListUI[i].SetActive(false);
        }
    }

    /// <summary>
    /// sets the current weapon image
    /// takes weapon name (pistol, shotgun etc)
    /// </summary>
    /// <param name="weapon"></param>
    public void SetWeapon(string weapon)
    {
        // loops for each weapon in weapon list
        for (int i = 0; i < weaponsListUI.Count; i++)
        {
            // checks if the current weapons name equals th weapon string
            if (weaponsListUI[i].name == weapon)
            {
                // sets current weapon to active
                weaponsListUI[i].SetActive(true);
            }
            else
            {
                // sets current weapon to inactive
                weaponsListUI[i].SetActive(false);
            }
        }
    }
}
