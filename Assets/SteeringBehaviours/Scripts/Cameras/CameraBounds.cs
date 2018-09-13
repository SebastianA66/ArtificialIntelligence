using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector3 size = new Vector3(50f, 0f, 20f);

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);

       
    }

    /// <summary>
    /// This function returns an adjusted vector3
    /// </summary>
    /// <param name="incomingPos"></param>
    /// <returns></returns>


    public Vector3 GetAdjustedPosition(Vector3 incomingPos)
    {
        //Get Bounds Position
        Vector3 pos = transform.position;
        Vector3 halfSize = size * 0.5f;

        if(incomingPos.z > pos.z + halfSize.z)
        {
            incomingPos.z = pos.z + halfSize.z;
        }

        if (incomingPos.z < pos.z - halfSize.z)
        {
            incomingPos.z = pos.z - halfSize.z;
        }

        if (incomingPos.x > pos.x + halfSize.x)
        {
            incomingPos.x = pos.x + halfSize.x;
        }

        if (incomingPos.x < pos.x - halfSize.x)
        {
            incomingPos.x = pos.x - halfSize.x;
        }

        if (incomingPos.y > pos.y + halfSize.y)
        {
            incomingPos.y = pos.y + halfSize.y;
        }

        if (incomingPos.y < pos.y - halfSize.y)
        {
            incomingPos.y = pos.y - halfSize.y;
        }

        return incomingPos;
    }
   
}
