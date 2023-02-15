using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundlayer, playerlayer;      

    //Partol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject projectilePos;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerlayer);

        //Partol
        if(!playerInSightRange && !playerInAttackRange) Patrol();
        //Chase
        if(playerInSightRange && !playerInAttackRange) Chase();
        //Attack
        if(playerInSightRange && playerInAttackRange) Attack();

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Patrol()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);
            Vector3 distanceWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if(distanceWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calculate new point
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, groundlayer))
            walkPointSet = true;
    }
    
    private void Chase()
    {
        
    }
    
    private void Attack()
    {

    }
}
