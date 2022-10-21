using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerSniper : MonoBehaviour
{
    // sets the look radius
    public float lookRadius;

    // creates the target transform
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        // sets the target to the player through the player manager
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // looks at the player
        Vector3 direction = (target.position - transform.position).normalized; // gets the direction to the player
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // sets the direction to the player as an angle
        transform.rotation = lookRotation; // rotates the enemy to look at the player
    }

    // draw gizmos in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // sets the colour to red
        Gizmos.DrawWireSphere(transform.position, lookRadius); // draws a sphere at the enemy with a radius of look radius
    }
}

