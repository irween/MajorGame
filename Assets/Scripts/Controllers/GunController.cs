using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{ 
    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public void ShootGun()
    {
        Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
    }
}
