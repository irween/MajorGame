using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // public variables
    public float speed = 40f;

    public int damage;

    // Update is called once per frame
    void Update()
    {
        // moves the gameobject by a designated amount every frame
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        damage = FindObjectOfType<PlayerCombatController>().damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
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
