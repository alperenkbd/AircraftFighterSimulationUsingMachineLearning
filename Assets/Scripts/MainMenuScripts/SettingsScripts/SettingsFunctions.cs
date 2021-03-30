using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.IO;

public class SettingsFunctions : MonoBehaviour
{
    private string HavaDurumu;
    private string IconText;
    private GameObject Fortyping;
    [SerializeField] Text WeatherData;
    [SerializeField] Text DateData;
    [SerializeField] Text HoursData;

    void Start()
    {
        DataAttachment();
        StartCoroutine(TextAnim());
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

    public void DataAttachment()
    {
        
        HavaDurumu = GetWeather().weather[0].main;
        DateData.text = DateTime.Now.Date.ToString("dd.MM.yyyy");
        
        int HourForSplit;
        string AmOrPm;
        HourForSplit = DateTime.Now.Hour;

        if (HourForSplit > 12)
            AmOrPm = "PM";
        else
            AmOrPm = "AM";
        HoursData.text = DateTime.Now.ToString("HH:mm ") + AmOrPm;

    }



    IEnumerator TextAnim()
    {
        WeatherData.text = "fetching";
        yield return new WaitForSeconds(0.5f);
        WeatherData.text = "fetching.";
        yield return new WaitForSeconds(0.5f);
        WeatherData.text = "fetching..";
        yield return new WaitForSeconds(0.5f);
        WeatherData.text = "fetching...";
        yield return new WaitForSeconds(1f);
        WeatherData.text = HavaDurumu;

    }
}
