using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int shotgunAmount;
    public int angleStart;
    private int angleModifier;
    private int angle;
    private Quaternion shotgunAngle;

    public int ammoAmount;

    private GameManager gameManager;

    public GameObject ammoText;

    public void ShootGun()
    {
        gameManager = FindObjectOfType<GameManager>();
        ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
        ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
        if (ammoAmount > 0)
        {
            angle = angleStart;
            angleModifier = -angleStart / 2;
            for (int i = 0; i < shotgunAmount; i++)
            {
                gameManager.GetComponent<AmmoManager>().shotgunAmmo--;
                angle += angleModifier;
                shotgunAngle = transform.rotation * Quaternion.AngleAxis(angle, Vector3.forward);
                Instantiate(projectilePrefab, transform.position + offset, shotgunAngle * Quaternion.Euler(0, 0, 90));
            }
        }
    }
}

