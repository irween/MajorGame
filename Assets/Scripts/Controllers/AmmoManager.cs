using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    // sets the start ammo for each type
    public int pistolAmmo;
    public int machinegunAmmo;
    public int shotgunAmmo;

    // sets the max amount of ammo each type can have
    public int pistolAmmoMax;
    public int machinegunAmmoMax;
    public int shotgunAmmoMax;

    // called by other scripts
    // increases/decreases the pistol ammo by "ammo"
    public void PistolAmmoUpdate(int ammo)
    {
        pistolAmmo += ammo; // increases pistol ammo by "ammo"
        pistolAmmo = Mathf.Clamp(pistolAmmo, 0, pistolAmmoMax); // clamps the ammo to stay within the max ammo value
    }

    // increases/decreases the machinegun ammo by "ammo"
    public void MachineGunAmmoUpdate(int ammo)
    {
        machinegunAmmo += ammo; // increases machinegun ammo by "ammo"
        machinegunAmmo = Mathf.Clamp(machinegunAmmo, 0, machinegunAmmoMax); // clamps the ammo to stay within the max ammo value
    }

    // increases/decreases the shotgun ammo by "ammo"
    public void ShotgunAmmoUpdate(int ammo)
    {
        shotgunAmmo += ammo; // increases shotgun ammo by "ammo"
        shotgunAmmo = Mathf.Clamp(shotgunAmmo, 0, shotgunAmmoMax); // clamps the ammo to stay within the max ammo value
    }
}
