using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int ammoAmount; 
    
    public GameObject ammoText;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        ammoAmount = gameManager.GetComponent<AmmoManager>().pistolAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
    }

    public void ShootGun()
    {
        ammoAmount = gameManager.GetComponent<AmmoManager>().pistolAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);

        if (ammoAmount > 0)
        {
            gameManager.GetComponent<AmmoManager>().pistolAmmo--;

            Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
        }
    }
}
