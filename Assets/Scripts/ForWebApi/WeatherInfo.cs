using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
}

    [Serializable]
    public class WeatherInfo
    {
        public int id;
        public string name;
        public List<Weather> weather;
    }

