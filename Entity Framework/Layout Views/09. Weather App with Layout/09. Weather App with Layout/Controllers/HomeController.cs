using _09._Weather_App_with_Layout.Models;
using Microsoft.AspNetCore.Mvc;

namespace _09._Weather_App_with_Layout.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";

            List<CityWeather> cityWeathers = new List<CityWeather>
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
                new CityWeather { CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60 },
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82 },
            };

            return View(cityWeathers);
        }

        [Route("/weather/{code}")]
        public IActionResult Details(string code)
        {
            ViewBag.Title = $"Home-{code}";

            List<CityWeather> cityWeathers = new List<CityWeather>
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
                new CityWeather { CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60 },
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82 },
            };

            CityWeather cityWeather = cityWeathers.Where(c => c.CityUniqueCode == code).FirstOrDefault();
            return View(cityWeather);
        }
    }
}
