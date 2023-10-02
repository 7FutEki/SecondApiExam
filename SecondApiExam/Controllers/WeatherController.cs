using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondApiExam.Interfaces;
using SecondApiExam.Models;

namespace SecondApiExam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        List<Weather> weathers = new List<Weather>()
        {
            new Weather()
            {
                Date = new DateOnly(2023, 09, 20),
                Temperature = 30,
                Description="Солнечно"
            },
            new Weather()
            {
                Date = new DateOnly(2023, 10, 02),
                Temperature = 23,
                Description="Небольшой дождь"
            },
            new Weather()
            {
                Date = new DateOnly(2023, 11, 15),
                Temperature = 15,
                Description="Снег"
            },
            new Weather()
            {
                Date = new DateOnly(2023, 08, 5),
                Temperature=26,
                Description="Солнечно"
            },
            new Weather()
            {
                Date = new DateOnly(2023, 09, 27),
                Temperature=18,
                Description="Пасмурно"
            }
        };
        List<City> cities = new List<City>()
        {
            new City()
            {
                Id=1,
                Name="Анапа"
            },
            new City()
            {
                Id=2,
                Name="Москва"
            },
            new City()
            {
                Id =3,
                Name="Нижний новгород"
            },
            new City()
            {
                Id = 4,
                Name="Самара"
            },
            new City()
            {
                Id=5,
                Name="Уфа"
            }
        };
             
        private readonly ITokenRepository _tokenRepository;

        public WeatherController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        [HttpGet("GetCities")]
        public IActionResult GetCities(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return Unauthorized("Не предоставлен временный токен.");
            }
            string tokenFromdb = _tokenRepository.Get();
            if (token != token)
            {
                return Unauthorized("Неверный токен");
            }
            else return Ok(cities);
        }

        [HttpGet("GetWeatherByCity")]
        public IActionResult GetWeathers(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return Unauthorized("Не предоставлен временный токен.");
            }
            string tokenfromdb = _tokenRepository.Get();
            if (tokenfromdb != token)
            {
                return Unauthorized("Неверный токен");
            }
            else return Ok(weathers);
        }
    }
}
