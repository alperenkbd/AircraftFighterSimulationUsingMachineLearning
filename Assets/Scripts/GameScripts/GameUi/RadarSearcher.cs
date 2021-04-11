using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarSearcher : MonoBehaviour
{

    [SerializeField] private float barSpeed=-2.0f;
    
    private void Update()
    {
        SearchBarTurner();
    }


    private void SearchBarTurner()
    {
         gameObject.transform.Rotate(new Vector3(0, 0, barSpeed));
    }

}
