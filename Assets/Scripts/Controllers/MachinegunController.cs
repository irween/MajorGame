using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunController : MonoBehaviour
{
    // sets the projectile prefab
    public GameObject projectilePrefab;

    // sets the ammo amount
    public int ammoAmount;

    // sets the ammo text ui
    public GameObject ammoText;

    // sets the gamemanager 
    private GameManager gameManager;

    private void Start()
    {
        // finds the gamemanager
        gameManager = FindObjectOfType<GameManager>();
        
        // setting the ammo amount and ammo text to the current ammo the player has (from gamemanager)
        ammoAmount = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
    }

    // called whenever the player shoots the gun
    // spawns the projectile with correct rotation
    // changes the ammo amounts
    public void ShootGun()
    {
        // setting the ammo amount and ammo text to the current ammo the player has (from gamemanager)
        ammoAmount = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
        // checking if there is enough ammo to shoot
        if (ammoAmount > 0)
        {
            // taking one ammo away from pistol ammo
            gameManager.GetComponent<AmmoManager>().machinegunAmmo--;

            // spawning the projectile
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
