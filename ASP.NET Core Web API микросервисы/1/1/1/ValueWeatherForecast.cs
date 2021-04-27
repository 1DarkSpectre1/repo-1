using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1
{
    public class ValueWeatherForecast
    {
        public List<WeatherForecast> ListWeatherForecast { get; set; }
        public void config()
        {
            ListWeatherForecast = new List<WeatherForecast>();
        }
        
    }
}
