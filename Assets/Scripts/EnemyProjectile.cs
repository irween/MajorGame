using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // speed of projectile
    public float speed = 40f;

    // damage of projectile
    public int damage;

    // Update is called once per frame
    void Update()
    {
        // moves the projectile every frame multiplied by speed
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    // when another object (other) collides with this (collider), enter
    private void OnTriggerEnter(Collider other)
    {
        // checks if other object has tag wall or floor
        if (other.gameObject.CompareTag("Wall") | other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }

        // checks if other object has tag player
        if (other.gameObject.CompareTag("Player"))
        {
            // triggers take damage function in player with an amount of damage
            other.gameObject.GetComponent<PlayerCombatController>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
