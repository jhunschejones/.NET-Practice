using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    
    public class WeatherResponse
    {
        public object[] consolidated_weather { get; set; }
        // public string Summary { get; set; }
        // public string Temperature { get; set; }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to the Weather endpoint. Navigate to `/portland` or `/dublin` to see local weather!";
        }
        
        [HttpGet("Portland")]
        public async Task<IActionResult> GetPortlandWeather()
        {
            using (var client = new HttpClient())
            {
                try 
                {
                    client.BaseAddress = new Uri("https://www.metaweather.com/");
                    var response = await client.GetAsync($"/api/location/2475687");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    // using dynamic type lets us parse through the data and send back only what we want
                    dynamic rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
                    string summary = rawWeather.consolidated_weather[0].weather_state_name;
                    double rawCelsius = rawWeather.consolidated_weather[0].the_temp;
                    // temperature rounded up to the nearest 10ths place
                    double temperature_celsius = Math.Ceiling(rawCelsius*10)/10;
                    double rawFahrenheit = (rawCelsius * 9/5) + 32;
                    double temperature_fahrenheit = Math.Ceiling(rawFahrenheit*10)/10;
                    string date = rawWeather.consolidated_weather[0].applicable_date;
                     return Ok(new {
                        date,
                        summary,
                        temperature_celsius,
                        temperature_fahrenheit
                    });
                }
                catch (HttpRequestException HttpRequestException)
                {
                    return BadRequest($"Error getting your Portland weather summary: {HttpRequestException.Message}");
                }
            }
        }

        [HttpGet("Dublin")]
        public async Task<IActionResult> GetDublinWeather()
        {
            using (var client = new HttpClient())
            {
                try 
                {
                    client.BaseAddress = new Uri("https://www.metaweather.com/");
                    var response = await client.GetAsync($"/api/location/560743");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    // using dynamic type lets us parse through the data and send back only what we want
                    dynamic rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
                    string summary = rawWeather.consolidated_weather[0].weather_state_name;
                    double rawCelsius = rawWeather.consolidated_weather[0].the_temp;
                    // temperature rounded up to the nearest 10ths place
                    double temperature_celsius = Math.Ceiling(rawCelsius*10)/10;
                    double rawFahrenheit = (rawCelsius * 9/5) + 32;
                    double temperature_fahrenheit = Math.Ceiling(rawFahrenheit*10)/10;
                    string date = rawWeather.consolidated_weather[0].applicable_date;
                     return Ok(new {
                        date,
                        summary,
                        temperature_celsius,
                        temperature_fahrenheit
                    });
                }
                catch (HttpRequestException HttpRequestException)
                {
                    return BadRequest($"Error getting your Dublin weather summary: {HttpRequestException.Message}");
                }
            }
        }

    }
}
