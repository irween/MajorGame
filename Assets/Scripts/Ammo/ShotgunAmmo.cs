using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    public GameObject shotgun;
    public int ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shotgun.GetComponent<GunController>().ammoAmount += ammo;
        }
    }
}
