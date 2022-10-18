using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    Transform playerTransform;

    public float lookAttackRadius = 25f;

    public GameObject projectilePrefab;

    public Vector3 offset = new Vector3(0, 0, 0);

    public float timeToFireInterval;

    private float timeToFire;

    void Start()
    {
        playerTransform = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        timeToFire = timeToFire -= Time.deltaTime;

        if (distance <= lookAttackRadius && timeToFire <= 0)
        {
            Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
            timeToFire = timeToFireInterval;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookAttackRadius);
    }
}
