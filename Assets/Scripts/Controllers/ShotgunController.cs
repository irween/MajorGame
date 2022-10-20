using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int shotgunAmount;
    public int angleStart;
    public int angleModifier;
    private int angle;
    private Quaternion shotgunAngle;

    public int ammoAmount;

    private GameManager gameManager;

    public GameObject ammoText;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
    }

    public void ShootGun()
    {
        ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
        gameManager.GetComponent<AmmoManager>().shotgunAmmo--;
        if (ammoAmount > 0)
        { 
            angle = angleStart;
            for (int i = 0; i < shotgunAmount; i++)
            { 
                angle += angleModifier;
                shotgunAngle = transform.rotation * Quaternion.AngleAxis(angle, Vector3.forward);
                Instantiate(projectilePrefab, transform.position + offset, shotgunAngle * Quaternion.Euler(0, 0, 90));
            }
        }
    }
}

