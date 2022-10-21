using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // set player transform
    Transform playerTransform;

    // set attack radius
    public float lookAttackRadius;

    // set projectile prefab
    public GameObject projectilePrefab;

    // interval between each shot
    public float timeToFireInterval;
    private float timeToFire;

    void Start()
    {
        // set player transform to player from playermanager
        playerTransform = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // find the distance between current object and player
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        // takes one away from time to fire every second
        timeToFire -= Time.deltaTime;

        // checks if distance to player is less than the attack radius and time to fire is less than or equal to 0
        if (distance <= lookAttackRadius && timeToFire <= 0)
        {
            // spawn projectile
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            timeToFire = timeToFireInterval; // resets time to fire
        }
    }

    // draws gizmos in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue; // sets gizmo colour
        Gizmos.DrawWireSphere(transform.position, lookAttackRadius); // draws sphere at object position with size of attack radius
    }
}
