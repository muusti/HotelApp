using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelServiceBase _hotelservice;
        public HotelController(HotelServiceBase hotelService)
        {
            _hotelservice = hotelService;
        }
        [HttpGet]
        public IActionResult GetHotels()
        {
            List<Hotel> hotelList = _hotelservice.GetList();
            return Ok(hotelList);
        }

        [HttpGet("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            Hotel hotel = _hotelservice.GetItem(id ?? 0);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult Post(Hotel hotel)
        {
            var result = _hotelservice.Add(hotel);
            if (result.IsSuccessful)
                return Ok(hotel);

            ModelState.AddModelError("", result.Message);
            return BadRequest(ModelState);
        }


        [HttpPut]
        public IActionResult Put(Hotel hotel)
        {
            var result = _hotelservice.Update(hotel);
            if (result.IsSuccessful)
                return Ok(hotel);
            ModelState.AddModelError("", result.Message);
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _hotelservice.Delete(h => h.Id == id);
            return Ok(id);
        }
    }
}
