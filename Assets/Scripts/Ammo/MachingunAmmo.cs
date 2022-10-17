using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachingunAmmo : MonoBehaviour
{
    public GameObject machinegun;
    public int ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            machinegun.GetComponent<GunController>().ammoAmount += ammo;
        }
    }
}