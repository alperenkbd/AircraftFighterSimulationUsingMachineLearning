using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    
    public Transform camTransform;
    public float shakeAmount = 0.3f;
    public float decreaseFactor = 0.5f;

    private float cameraSpeed = 90.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void Update()
    {
        
        originalPos = camTransform.localPosition;
    }

    
    

    public void Shaker(bool istrue)
    {
        if (istrue)
        {
            transform.position = transform.forward * Time.deltaTime * cameraSpeed;
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }
        else
        {
            camTransform.localPosition = originalPos;
        }
            
        
    }
}

