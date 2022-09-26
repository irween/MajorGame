using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    private bool foundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("robot");
    }

    // Update is called once per frame
    void Update()
    {
        if (foundPlayer)
        {
            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        }
    }

}

