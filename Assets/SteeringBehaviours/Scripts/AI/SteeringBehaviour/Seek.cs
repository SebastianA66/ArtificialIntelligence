using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance;
        public override Vector3 GetForce()
        {
            // Get direction to target
            Vector3 velocity = target.position - owner.transform.position;
            // Normalize direction (remove the magnitude part of vector)
            velocity.Normalize();
            // return velocity (direction x speed)
            return velocity * owner.maxSpeed;
        }
    }
}

