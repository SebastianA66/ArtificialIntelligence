using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgent : MonoBehaviour
    {

        public Transform target;

        private NavMeshAgent agent;

        // Update is called once per frame
        void Update()
        {

            agent.SetDestination(target.position);


        }

    }
}
