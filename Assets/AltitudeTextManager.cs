using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AltitudeTextManager : MonoBehaviour
{

    public GetAltitude getaltitude;
    public Text altitudeText;
    private int altitude;

    private void Update()
    {
        altitude =(int)getaltitude.GetAltitudeFunc();
        altitudeText.text = altitude.ToString() + "m";
    }
}
