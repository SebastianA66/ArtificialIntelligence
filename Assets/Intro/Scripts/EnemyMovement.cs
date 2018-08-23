using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Intro
{
    public class EnemyMovement : MonoBehaviour
    {

        //public Transform[] waypoints;

        public Transform waypointParent;
        public float stoppingDistance = 1f;

        private Transform[] waypoints;


        //defining waypoints
        private int currentIndex = 1;
        //The destination points
        private NavMeshAgent agent;
        // defining navigational floors for the enemy


        // Use this for initialization
        void Start()
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>();

            agent = GetComponent<NavMeshAgent>();

        }

        void Update()
        {
            Transform point = waypoints[currentIndex];

            float distance = Vector3.Distance(transform.position, point.position); //transform.position is the agent
            if (distance < stoppingDistance)
            {
                // currentIndex += 1
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }
            }
            agent.SetDestination(point.position);
        }
    }
}
