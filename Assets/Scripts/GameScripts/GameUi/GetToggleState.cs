using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToggleState : MonoBehaviour
{

    void Start()
    {
        Debug.Log("toggle state is: " + PlayerPrefs.GetInt("toggle"));
    }

    
}
