using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShootController : MonoBehaviour
{
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform.position);
    }
}
