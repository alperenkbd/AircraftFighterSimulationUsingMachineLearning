using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField] bool togglebool;
    public Toggle toggle;
    
    public void StartToFlightButton()
    {
        togglebool = toggle.isOn;

        if (togglebool)
        {
            PlayerPrefs.SetInt("toggle", 1);
        }
        else
        {
            PlayerPrefs.SetInt("toggle", 0);
        }
    }

        
        
    
}
