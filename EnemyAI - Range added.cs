using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; // means gigantic number
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
   
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
        
        //SetDestination();
    }

    // void SetDestination()
    // {
    //     navMeshAgent.destination = target.position;
    // }
}
