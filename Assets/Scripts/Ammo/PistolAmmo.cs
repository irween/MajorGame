using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmo : MonoBehaviour
{
    private GameManager gameManager;
    public int ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.GetComponent<AmmoManager>().PistolAmmoUpdate(ammo);
            Destroy(gameObject);
        }
    }
}
