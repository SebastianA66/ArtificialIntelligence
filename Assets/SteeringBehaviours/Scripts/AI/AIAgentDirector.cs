using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {

        public AIAgent agent;
        public Transform placeholderPoint;
        private void OnDrawGizmosSelected()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Draw a line from the
            // - start; where the ray starts from
            // - end; where the ray is going 
            Gizmos.color = Color.red;
            Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
        }
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //try to get seek component on agent
                Seek seek = agent.GetComponent<Seek>();
                //if seek is not null
                if(seek)
                {
                    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(camRay, out hit, 1000f))
                    {
                        //update the transform's position
                        placeholderPoint.position = hit.point;
                        //update seek's target
                        seek.target = placeholderPoint;
                    }
                }
                
            }
           



        }

        
    }
}
