using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ValueWeatherForecast _holder;
     
        public CrudController(ValueWeatherForecast holder)
        {
            this._holder = holder;
            if (_holder.ListWeatherForecast==null)
            {
                _holder.config();
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime date, int temperatureC)
        {
            _holder.ListWeatherForecast.Add(new WeatherForecast() { Date = date, TemperatureC= temperatureC }) ;
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime date_begin, DateTime date_end)
        {
            List<WeatherForecast> readList = new List<WeatherForecast>();
            DateTime date = new DateTime();
            if (date_begin== date || date_end== date)
            {
                return Ok(_holder.ListWeatherForecast);
            }
            if (_holder.ListWeatherForecast!=null)
            {
                foreach (WeatherForecast itemweatherForecast in _holder.ListWeatherForecast)
                {
                    if (itemweatherForecast.Date >= date_begin && itemweatherForecast.Date <= date_end)
                        readList.Add(itemweatherForecast);
                }
                
            }
            return Ok(readList);
        }
        

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, int newtemperatureC)
        {
            for (int i = 0; i < _holder.ListWeatherForecast.Count; i++)
            {
                if (_holder.ListWeatherForecast[i].Date == date)
                    _holder.ListWeatherForecast[i].TemperatureC = newtemperatureC;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date_begin, DateTime date_end)
        {
            foreach (WeatherForecast itemweatherForecast in _holder.ListWeatherForecast)
            {
                if (itemweatherForecast.Date >= date_begin && itemweatherForecast.Date <= date_end)
                    _holder.ListWeatherForecast.Remove(itemweatherForecast);
            }
            return Ok();
        }

    }
}
