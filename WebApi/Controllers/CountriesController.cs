using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountryServiceBase _countryService;

        public CountriesController(CountryServiceBase countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Country> countryList = _countryService.GetList();
            return Ok(countryList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Country country = _countryService.GetItem(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult Post(Country country)
        {
            var result = _countryService.Add(country);
            if (result.IsSuccessful)
                return CreatedAtAction("Get", new { id = country.Id }, country);

            ModelState.AddModelError("", result.Message);
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Country country)
        {
            var result = _countryService.Update(country);
            if (result.IsSuccessful)
                return NoContent();
            ModelState.AddModelError("", result.Message);
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _countryService.Delete(c => c.Id == id);
            return NoContent();
        }
    }
}
