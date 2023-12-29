using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TheLearningHub.Core.DTO;

namespace TheLearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
        {
        [HttpGet]
        [Route("GetWeatherByCityName/{cityName}")]
        public async Task<Weather> GetWeatherByCityName(string cityName)
            {
            using (var client = new HttpClient())
                {
                var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=511ba00e6b1fdebcf7456541e7a16390&units=metric");
               var resultAsString = await response.Content.ReadAsStringAsync();
                var finalresult = JsonConvert.DeserializeObject<Weather>(resultAsString);
                return finalresult;
                }
            }
        }
    }
