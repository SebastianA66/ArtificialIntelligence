using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    public Transform[] waypoints;
    private int destPoint = 0;
    private NavMeshAgent agent;

     
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (waypoints.Length == 2)
            return;

        agent.destination = waypoints[destPoint].position;
        destPoint = (destPoint + 1) % waypoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 2f)
            GoToNextPoint();
    }
}
