using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int ammoAmount;

    private GameManager gameManager;

    public void ShootGun()
    {
        gameManager = FindObjectOfType<GameManager>();
        ammoAmount = gameManager.GetComponent<AmmoManager>().machinegunAmmo;

        if (ammoAmount > 0)
        {
            gameManager.GetComponent<AmmoManager>().machinegunAmmo--;

            Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
        }
    }
}
