using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerDefault : MonoBehaviour
{
    public float lookRadius = 10f;

    public float lookAttackRadius = 1f;

    private Animator animator;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            FaceTarget();
            agent.SetDestination(target.position);
            animator.SetBool("Running", true);
            animator.SetBool("Attacking", false);
        }
        
        else
        {
            animator.SetBool("Running", false);
        }

        if (distance <= lookAttackRadius)
        {
            animator.SetBool("Attacking", true);
            animator.SetBool("Running", false);
        }

        else
        {
            animator.SetBool("Attacking", false);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, lookAttackRadius);
    }
}

