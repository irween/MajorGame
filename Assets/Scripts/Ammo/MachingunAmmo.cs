using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachingunAmmo : MonoBehaviour
{
    private GameManager gameManager;
    public int ammoAmount;
    private AmmoUIManager ammoText;
    private int currentGun;
    private int currentAmmo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            ammoText = FindObjectOfType<AmmoUIManager>();
            gameManager.GetComponent<AmmoManager>().MachineGunAmmoUpdate(ammoAmount);

            currentGun = other.GetComponent<RobotAnimationController>().currentGun;
            if (currentGun == 2)
            {
                currentAmmo = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
                ammoText.UpdateAmmo(currentAmmo);
            }
            Destroy(gameObject);
        }
    }
}