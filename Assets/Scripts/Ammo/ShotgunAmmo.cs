using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    private GameManager gameManager;
    public int ammoAmount;
    public AmmoUIManager ammoText;
    private int currentGun;
    private int currentAmmo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            ammoText = FindObjectOfType<AmmoUIManager>();
            gameManager.GetComponent<AmmoManager>().ShotgunAmmoUpdate(ammoAmount);

            currentGun = other.GetComponent<RobotAnimationController>().currentGun;
            if (currentGun == 3)
            {
                currentAmmo = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
                ammoText.UpdateAmmo(currentAmmo);
            }
            Destroy(gameObject);
        }
    }
}
