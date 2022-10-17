using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int ammoAmount;

    private GameManager gameManager;

    public void ShootGun()
    {
        gameManager = FindObjectOfType<GameManager>();
        ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;

        if (ammoAmount > 0)
        {
            gameManager.GetComponent<AmmoManager>().shotgunAmmo--;

            Instantiate(projectilePrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, 90));
        }
    }
}

