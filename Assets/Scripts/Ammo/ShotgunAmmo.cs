using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    // ammo ui
    public int ammoAmount; // ammo amount to add
    public AmmoUIManager ammoText; // ammo text ui

    // current values
    private int currentGun;
    private int currentAmmo;

    // set gamemanager
    private GameManager gameManager;

    // when another object (other) collides with this (collider), enter
    private void OnTriggerEnter(Collider other)
    {
        // checks if the other game object has the tag player
        if (other.gameObject.CompareTag("Player"))
        {
            // find objects
            gameManager = FindObjectOfType<GameManager>();
            ammoText = FindObjectOfType<AmmoUIManager>();

            // update ammo amount
            gameManager.GetComponent<AmmoManager>().ShotgunAmmoUpdate(ammoAmount);

            // set ammo text to correct ammo type
            currentGun = other.GetComponent<RobotAnimationController>().currentGun; // get current gun from player
            // checks if the current gun equals 3 (shotgun)
            if (currentGun == 3) 
            {
                // gets current gun ammo
                currentAmmo = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
                ammoText.UpdateAmmo(currentAmmo); // updates ammo text
            }
            Destroy(gameObject);
        }
    }
}
