using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    public GameObject[] ammo;

    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public int resistance = 0;

    public Vector3 offset = new Vector3(0, 1, 0);

    public int ammoIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        damage -= resistance;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        Debug.Log(transform.name + " took " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ammoIndex =  Random.Range(0, ammo.Length);
        Instantiate(ammo[ammoIndex], transform.position + offset, ammo[ammoIndex].transform.rotation);

        Destroy(gameObject);
        Debug.Log(transform.name + " died");
    }
}
