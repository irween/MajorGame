using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShootController : MonoBehaviour
{
    // creates player transform variable
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // sets the player transform variable to the player through the player manager
        playerTransform = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // makes the enemy gun look at the players position
        transform.LookAt(playerTransform.position);
    }
}
