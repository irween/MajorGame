using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    // sets the projectile prefab
    public GameObject projectilePrefab;

    // variables for the shotgun spread
    public int shotgunAmount; // the amount of projectiles in one shot
    public int angleStart; // the angle the shotgun starts at
    public int angleModifier; // the amount to increase angle start by (the amount of spread)
    private int angle; // private variable to set angle
    private Quaternion shotgunAngle; // private variable to add to the shotgun rotation

    // the ammo amount
    public int ammoAmount;

    // sets the ammo text ui object
    public GameObject ammoText;

    // sets the gamemanager object
    private GameManager gameManager;

    private void Start()
    {
        // find the gamemanager
        gameManager = FindObjectOfType<GameManager>();

        // setting the ammo amount and ammo text to the current ammo the player has (from gamemanager)
        ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
    }

    // called whenever the player shoots the gun
    // spawns the projectile with correct rotation and spreads the projectiles
    // changes the ammo amounts
    public void ShootGun()
    {
        // setting the ammo amount and ammo text to the current ammo the player has (from gamemanager)
        ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);

        // checking if there is enough ammo to shoot (must be above 0)
        if (ammoAmount > 0)
        { 
            // removing one from the shotgun ammo in gamemanager
            gameManager.GetComponent<AmmoManager>().shotgunAmmo--;

            // setting the angle to the start angle
            angle = angleStart;

            // replays for the length of shotgun amount
            for (int i = 0; i < shotgunAmount; i++)
            { 
                angle += angleModifier; // increases the angle by angle modifier
                shotgunAngle = transform.rotation * Quaternion.AngleAxis(angle, Vector3.forward); // changes shotgun angle to the angle of the current gameobject with the angle added
                Instantiate(projectilePrefab, transform.position, shotgunAngle * Quaternion.Euler(0, 0, 90)); // instantiates the projectile with the angle of the bullet
            }
        }
    }
}

