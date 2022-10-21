using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // speed of projectile
    public float speed = 40f;

    // projectile damage
    public float damage;

    // Update is called once per frame
    void Update()
    {
        // moves the projectile every frame multiplied by speed
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        // gets damage from player
        damage = FindObjectOfType<PlayerCombatController>().playerDamage;
    }

    // when another object (other) collides with this (collider), enter
    private void OnTriggerEnter(Collider other)
    {
        // checks if the other object has the tag wall or floor
        if (other.gameObject.CompareTag("Wall") | other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }

        // checks if the other object has the tag enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // triggers the take damage function from the other object
            other.gameObject.GetComponent<EnemyCombatController>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
