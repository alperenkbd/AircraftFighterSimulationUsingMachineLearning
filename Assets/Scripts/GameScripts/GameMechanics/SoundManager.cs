using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource FireAudio;




    private void Update()
    {
        FireSound();
    }

    private void FireSound()
    {
        if (PlayerPrefs.GetInt("toggle") == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                FireAudio.Play();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {

                FireAudio.Stop();
            }
        }else if (PlayerPrefs.GetInt("toggle") == 0)
        {
            if (ArduinoSerial.valueOfFire == 0)
            {
                FireAudio.Play();
            }

            if (ArduinoSerial.valueOfFire == 1)
            {
                FireAudio.Stop();
            }
        }
    }
}
