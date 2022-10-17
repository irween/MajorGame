using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{ 
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public int ammoAmount;

    public void ShootGun()
    {
        if (ammoAmount > 0)
        {
            Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
        }

        ammoAmount -= 1;
    }
}
