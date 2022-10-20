using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int ammoAmount;

    public GameObject ammoText;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ammoAmount = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
    }

    public void ShootGun()
    {
        ammoAmount = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);

        if (ammoAmount > 0)
        {
            gameManager.GetComponent<AmmoManager>().machinegunAmmo--;

            Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
        }
    }
}
