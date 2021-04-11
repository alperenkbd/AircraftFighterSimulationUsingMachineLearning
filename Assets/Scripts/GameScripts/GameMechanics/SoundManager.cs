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
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

            FireAudio.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            FireAudio.Stop();
        }

    }
}
