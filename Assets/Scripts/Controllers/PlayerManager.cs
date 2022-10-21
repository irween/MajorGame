using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // instances the player game object
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    // sets the player game object
    public GameObject player;

    private void Update()
    {
        // finds the player game object
        player = GameObject.Find("player");
    }
}