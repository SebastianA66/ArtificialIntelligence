﻿using System.Collections;
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
            Vector3 force = Vector3.zero;
            if(target)
            {
                // Get direction to target
                Vector3 direction = target.position - owner.transform.position;
                // Normalize direction (remove the magnitude part of vector)
                direction.Normalize();
                // return velocity (direction x speed)
                force = direction * owner.maxSpeed;
            }
            return force;
        }
    }
}

