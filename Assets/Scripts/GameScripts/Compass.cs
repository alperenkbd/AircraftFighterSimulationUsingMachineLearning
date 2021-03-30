using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compass;
    public Transform player;

    void Update()
    {

        compass.uvRect = new Rect(player.localEulerAngles.y / 360f, 0, 1, 1);

    }
}
