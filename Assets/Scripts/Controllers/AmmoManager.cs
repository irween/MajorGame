using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public int pistolAmmo;
    public int machinegunAmmo;
    public int shotgunAmmo;
    
    public int pistolAmmoMax;
    public int machinegunAmmoMax;
    public int shotgunAmmoMax;

    public void PistolAmmoUpdate(int ammo)
    {
        pistolAmmo += ammo;
        pistolAmmo = Mathf.Clamp(pistolAmmo, 0, pistolAmmoMax);
    }
    
    public void MachineGunAmmoUpdate(int ammo)
    {
        machinegunAmmo += ammo;
        machinegunAmmo = Mathf.Clamp(machinegunAmmo, 0, machinegunAmmoMax);
    }
    
    public void ShotgunAmmoUpdate(int ammo)
    {
        shotgunAmmo += ammo;
        shotgunAmmo = Mathf.Clamp(shotgunAmmo, 0, shotgunAmmoMax);
    }
}
