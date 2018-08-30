using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgent : MonoBehaviour
    {
        public NavMeshAgent agent;

        private Vector3 point;

        //private NavMeshAgent agent;

        // Update is called once per frame

        void Update()
        {
            if (point.magnitude > 0) //if there is a point set
            {
                agent.SetDestination(point); //Set the agents destination to the point
            }
            
        }

        
        public void SetTarget(Vector3 point)
        {
            this.point = point;
        }
    }
}
