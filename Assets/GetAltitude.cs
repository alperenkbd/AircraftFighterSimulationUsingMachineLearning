using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAltitude : MonoBehaviour
{
    RaycastHit hit;
    long altitude;
    

    // Update is called once per frame
    void Update()
    {
        GetAltitudeFunc();
    }

    public float GetAltitudeFunc()
    {
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down)
            ,out hit ,5000f) && hit.collider.tag == "Terrain")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)
            * 5000f, Color.green);
            
                altitude = (long)hit.distance;
            
        }
        return altitude;
    }
}
