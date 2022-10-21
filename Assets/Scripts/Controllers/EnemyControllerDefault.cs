using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerDefault : MonoBehaviour
{
    // sets look radius (radius that the enemy can find the player)
    public float lookRadius;

    // sets attack radius (radius that the enemy can attack the player)
    public float lookAttackRadius;

    // setting the animator
    private Animator animator;

    Transform target; // creating the transform target
    NavMeshAgent agent; // creatting the navmesh agent

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform; // sets target transform to player through player manager
        agent = GetComponent<NavMeshAgent>(); // sets the agent to the current game objects nav mesh component

        // gets the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // sets the distance to the player
        float distance = Vector3.Distance(target.position, transform.position);

        // checks if the distance to the player is within the look radius
        if (distance <= lookRadius)
        {
            // face the player
            FaceTarget();

            agent.SetDestination(target.position); // sets navmesh destination to the player to move to the player
            animator.SetBool("Running", true); // sets the running animation to true
            animator.SetBool("Attacking", false); // sets the attacking animation to false
        }
        
        else
        {
            animator.SetBool("Running", false); // sets the running animation to false when the player is out of the look radius
        }

        // checks if the distance to the player is within the attack radius
        if (distance <= lookAttackRadius)
        {
            animator.SetBool("Attacking", true); // sets attacking animation to true
            animator.SetBool("Running", false); // sets running animation to false
        }

        else
        {
            animator.SetBool("Attacking", false); // sets the attacking animation to false when the player is out of the attack radius
        }
    }

    // called when the player is within the look radius
    // faces the player
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; // sets the direction to the direction to the player
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // gets the angle to the player based on the direction
        transform.rotation = lookRotation; // sets the rotation of the enemy to look at the player
    }

    // draws gizmos in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // sets colour to red
        Gizmos.DrawWireSphere(transform.position, lookRadius); // draws sphere at enemy position with radius of look radius 
        Gizmos.DrawWireSphere(transform.position, lookAttackRadius); // draws sphere at enemy position with radius of attack radius 
    }
}

