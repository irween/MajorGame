using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // public variables
    public float speed = 40f;

    public float damage;

    // Update is called once per frame
    void Update()
    {
        // moves the gameobject by a designated amount every frame
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        damage = FindObjectOfType<PlayerCombatController>().playerDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") | other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyCombatController>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
