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
            return base.GetForce();
        }
    }
}

