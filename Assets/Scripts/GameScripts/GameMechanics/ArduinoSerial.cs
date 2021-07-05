using UnityEngine;
using System.IO.Ports;
using System;
using System.Collections;
using Unity.Jobs;
using System.Threading;

public class ArduinoSerial : MonoBehaviour
{

    

    SerialPort serial = new SerialPort("COM6", 9600);

    public static float valueOfPitch;
    public static float valueOfRoll;
    public static int valueOfFire;
    bool isStreaming;
    int values;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("toggle") == 0)
        {
            serial.Open();
            Thread thread = new Thread(new ThreadStart(ReadDatasFromArduino));
            thread.Start();
            isStreaming = true;
            Debug.Log("port opened succes");
        }
        
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("toggle") == 0)
            ReadDatasFromArduino();
    }


    private void  ReadDatasFromArduino()
    {
        try
        {
            valueOfPitch = (float.Parse(serial.ReadLine())-512)/512;
            valueOfRoll = (float.Parse(serial.ReadLine())-512)/512;
            valueOfFire = (int.Parse(serial.ReadLine()));
            //Debug.Log("pitch value: " + valueOfPitch + "\n");
            //Debug.Log("roll value: " + valueOfRoll + "\n");
            //Debug.Log("fire value: " + valueOfFire + "\n");
        } catch(Exception e)
        {
            Debug.Log(e);
        }
    }
    
}
