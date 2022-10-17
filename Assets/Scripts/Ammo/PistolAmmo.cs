using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmo : MonoBehaviour
{
    public GameObject pistol;
    public int ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pistol.GetComponent<GunController>().ammoAmount += ammo;
        }
    }
}
