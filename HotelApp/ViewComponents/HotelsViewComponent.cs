using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace HotelApp.ViewComponents
{
    public class HotelsViewComponent : ViewComponent
    {
        private readonly HotelServiceBase _hotelService;

        public HotelsViewComponent(HotelServiceBase hotelService)
        {
            _hotelService = hotelService;
        }
        public ViewViewComponentResult Invoke()
        {
            var hotel = _hotelService.GetListAsync();
            var result = hotel.Result;
            return View(result);
        }
    }
}
