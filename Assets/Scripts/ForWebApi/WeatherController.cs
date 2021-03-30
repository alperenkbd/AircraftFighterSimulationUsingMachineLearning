using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;

public class WeatherController : MonoBehaviour
{
    
    public GameObject SnowSystem;
    public GameObject RainSystem;
    public GameObject CloudSystem;

    [SerializeField] GameObject Plane;
    [SerializeField] Material MorningSkyMaterial;
    [SerializeField] Material AfternoonSkyMaterial;
    [SerializeField] Material NightSkyMaterial;

    private int DateTimeInt;

    void Start()
    {
        CheckWeatherStatus();
        CheckClockAndMaterialAttach();
       Debug.Log(Plane.transform.position);
    }


    private void Update()
    {
        RainSystem.transform.position =new Vector3(Plane.transform.position.x, Plane.transform.position.y+30, Plane.transform.position.z);
        SnowSystem.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y + 15, Plane.transform.position.z);
        CloudSystem.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y + 30, Plane.transform.position.z);
    }


    public void CheckWeatherStatus()
    {
        string weather = GetWeather().weather[0].main;
        Debug.Log(weather);
        switch (weather) {

            case "Snow":
                SnowSystem.SetActive(true);
                break;
            case "Rain":
                RainSystem.SetActive(true);
                break;
            case "Clouds":
                CloudSystem.SetActive(true);
                break;
            default:
                
                break;

        }
    }


    private void CheckClockAndMaterialAttach()
    {
        DateTimeInt = DateTime.Now.Hour;

        if (DateTimeInt > 20)
            RenderSettings.skybox = NightSkyMaterial;
        else if(DateTimeInt >12)
            RenderSettings.skybox = AfternoonSkyMaterial;
        else
            RenderSettings.skybox = MorningSkyMaterial;

    }


    private WeatherInfo GetWeather()
    {
        HttpWebRequest request =
        (HttpWebRequest)WebRequest.Create(
            String.Format("http://api.openweathermap.org/data/2.5/weather?q=Ankara&appid=42eb2e669bb42294a7f38775809fabeb"
         ));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        return info;
    }
}
