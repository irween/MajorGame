using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public List<GameObject> weapons;

    public void Shoot(int gun)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == gun)
            {
                if (weapons[i].transform.name.ToLower() == "pistol")
                {
                    weapons[i].GetComponent<PistolController>().ShootGun();
                }

                if (weapons[i].transform.name.ToLower() == "machinegun")
                {
                    weapons[i].GetComponent<MachinegunController>().ShootGun();
                }

                if (weapons[i].transform.name.ToLower() == "shotgun")
                {
                    weapons[i].GetComponent<ShotgunController>().ShootGun();
                }
            }
        }
    }
}
