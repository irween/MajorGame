using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUIManager : MonoBehaviour
{
    // sets amo text
    public TextMeshProUGUI ammoText;

    /// <summary>
    /// updates the amount of ammo the ammo text displays
    /// ammo refers to how much ammo the player currently has
    /// </summary>
    /// <param name="ammo"></param>
    public void UpdateAmmo(int ammo)
    {
        // changes the ammo text to the current ammo
        ammoText.text = ammo.ToString();
    }
}
