using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;


namespace SteeringBehaviours
{
    public class Wander : SteeringBehaviour
    {
        public float offset = 1f;
        public float radius = 1f;
        public float jitter = .2f;

        private Vector3 targetDir;
        private Vector3 randomDir;

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            /*
            -32767                                             32767
             |------------------------0------------------------|
                        |___________________________|
                                Random Range

             */
            // Hex 0x7fff = 32767
            float randX = Random.Range(0, 0x7fff) - (0x7fff / 2);
            float randZ = Random.Range(0, 0x7fff) - (0x7fff / 2);

            #region Calculate randomDir
            // Create the randomDir
            randomDir = new Vector3(randX, 0, randZ);
            // Normalise randomDir
            randomDir.Normalize();
            // Apply jitter to it
            randomDir *= jitter;
            #endregion

            #region Calculate targetDir
            // Offset targetDir with randomDir
            targetDir += randomDir;
            // Normalise the targetDir
            targetDir.Normalize();
            // Apply radius to it
            targetDir *= radius;
            #endregion

            // Seek logic
            Vector3 seekPos = transform.position + targetDir;
            // Offset the seek position
            seekPos += transform.forward * offset;

            #region GizmosGL
            GizmosGL.color = Color.red;
            GizmosGL.AddCircle(seekPos + Vector3.up * .11f, .5f, Quaternion.LookRotation(Vector3.down));
            Vector3 offsetPos = transform.position + transform.forward * offset;

            GizmosGL.color = Color.blue;
            GizmosGL.AddCircle(offsetPos + Vector3.up * .1f, radius, Quaternion.LookRotation(Vector3.down));

            GizmosGL.color = Color.cyan;
            GizmosGL.AddLine(transform.position, offsetPos, .1f, .1f);
            #endregion

            // Calculate direction
            Vector3 direction = seekPos - transform.position;

            Vector3 desiredForce = Vector3.zero;
            // Check if direction is valid
            if(direction != Vector3.zero) // or direction.magnitude != 0
            {
                // Apply a weighting to the direction
                desiredForce = direction.normalized * weighting;
                // Apply to force
                force = desiredForce - owner.velocity;
            }

            return force;
        }

    }
}
