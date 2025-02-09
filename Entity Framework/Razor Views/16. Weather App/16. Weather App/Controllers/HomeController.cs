using _16._Weather_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace _16._Weather_App.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = new List<CityWeather>
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33},
                new CityWeather { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60},
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82}
            };

            return View(cityWeathers);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            List<CityWeather> cityWeathers = new List<CityWeather>
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33},
                new CityWeather { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60},
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82}
            };

            CityWeather? city = cityWeathers.Where(c => c.CityUniqueCode == cityCode).FirstOrDefault();
            if (city == null)
                return NotFound($"{cityCode} can not found.");

            return View(city);
        }
    }
}
