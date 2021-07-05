using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPlaneMov : MonoBehaviour
{

    private float PlaneSpeed = 90.0f;
    private Rigidbody PlaneRigidbody;
    [SerializeField] Camera MainCamera;
    [SerializeField] Image SecondCrosshair;
    [SerializeField] RawImage firstCrosshair;

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



        if (PlayerPrefs.GetInt("toggle") == 1)
        {
            transform.position -= transform.forward * Time.deltaTime * PlaneSpeed;
            transform.Rotate(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        }
        else
        {
            transform.position -= transform.forward * Time.deltaTime * PlaneSpeed;
            transform.Rotate(ArduinoSerial.valueOfPitch, 0f, ArduinoSerial.valueOfRoll);
        }
        
        
    }


    private void CameraFollow()
    {
        Vector3 MoveCam = transform.position + transform.forward * 80.0f + 
            Vector3.up * 40.0f;

        float bias = 0.93f;
        Camera.main.transform.position = (Camera.main.transform.position * bias) +
                                         MoveCam * (1.0f-bias);
        Camera.main.transform.LookAt(transform.position - transform.forward * 13.0f);

        SecondCrosshair.gameObject.SetActive(false);
        firstCrosshair.gameObject.SetActive(true);

        if (Input.GetMouseButton(1))
        {
            MoveCam = transform.position - transform.forward * 125.0f +
            Vector3.up * 60.0f;

            Camera.main.transform.position = (Camera.main.transform.position * bias) +
                                         MoveCam * (1.0f - bias);
            Camera.main.transform.LookAt(transform.position - transform.forward * 180.0f);

            SecondCrosshair.gameObject.SetActive(true);
            firstCrosshair.gameObject.SetActive(false);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Debug.Log("1");
        }
    }

    
    
    
}
