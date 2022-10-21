using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // list of weapons
    public List<GameObject> weapons;

    /// <summary>
    /// triggers the shoot action of the corresponding gun
    /// takes int gun which corresponds to a gun
    /// </summary>
    /// <param name="gun"></param>
    public void Shoot(int gun)
    {
        // loops for each item in weapons list
        for (int i = 0; i < weapons.Count; i++)
        {
            // checks if current gun equals gun int
            if (i == gun)
            {
                // checks if the name of the current gun equals pistol, machine gun, or shotgun
                if (weapons[i].transform.name.ToLower() == "pistol")
                {
                    weapons[i].GetComponent<PistolController>().ShootGun(); // shoots pistol
                }

                if (weapons[i].transform.name.ToLower() == "machinegun")
                {
                    weapons[i].GetComponent<MachinegunController>().ShootGun(); // shoots machinegun
                }

                if (weapons[i].transform.name.ToLower() == "shotgun")
                {
                    weapons[i].GetComponent<ShotgunController>().ShootGun(); // shoots shotgun
                }
            }
        }
    }
}
