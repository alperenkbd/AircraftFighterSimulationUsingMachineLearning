using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlaneMov : MonoBehaviour
{

    private float PlaneSpeed = 90.0f;
    private Rigidbody PlaneRigidbody;
    [SerializeField] Camera MainCamera;
    
    void Start()
    {
        
        PlaneRigidbody = GetComponent<Rigidbody>();
        Debug.Log(System.DateTime.Now.ToString("HH:mm"));
    }

    private void FixedUpdate()
    {
        PlaneMovement();
        if (MainCamera.enabled) {
            CameraFollow();
        }
        
    }


    
    private void PlaneMovement()
    {
        
       if (!Input.anyKey)
            transform.rotation = Quaternion.Lerp(transform.rotation
                , Quaternion.Euler(0, transform.eulerAngles.y, 0), Time.deltaTime);
        
        
            

        transform.position -= transform.forward * Time.deltaTime * PlaneSpeed;
        transform.Rotate(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        
    }


    private void CameraFollow()
    {
        Vector3 MoveCam = transform.position - transform.forward * 15.0f + Vector3.up * 5.0f;
        float bias = 0.93f;
        Camera.main.transform.position = (Camera.main.transform.position * bias) +
                                         MoveCam * (1.0f-bias);
        Camera.main.transform.LookAt(transform.position - transform.forward * 10.0f);


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Debug.Log("1");
        }
    }

    
    
    
}
