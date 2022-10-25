using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class CitiesController : Controller
    {
        private readonly CityServiceBase _cityService;

        public CitiesController(CityServiceBase cityService)
        {
            _cityService = cityService;
        }

        public IActionResult GetJson(int countryId)
        {
            var cities = _cityService.GetList(c => c.CountryId == countryId); 
            return Json(cities);
        }
    }
}
