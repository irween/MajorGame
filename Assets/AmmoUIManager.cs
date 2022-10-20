using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUIManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject player;

    public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UpdateAmmo(int ammo)
    {
        ammoText.text = ammo.ToString();
    }
}
