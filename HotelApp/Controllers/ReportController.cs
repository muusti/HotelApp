using DataAccess.Models;
using DataAccess.Services.Bases;
using HotelApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly CustomerServiceBase _customerService;
        private readonly RoomServiceBase _roomService;
        private readonly HotelServiceBase _hotelService;
        private readonly IReportServiceBase _reportService;
        private readonly CountryServiceBase _countryService;
        private readonly CityServiceBase _cityService;



        public ReportController(HotelServiceBase hotelService, CustomerServiceBase customerService, RoomServiceBase roomService, IReportServiceBase reportService, CountryServiceBase countryService, CityServiceBase cityService)
        {
            _hotelService = hotelService;
            _customerService = customerService;
            _roomService = roomService;
            _reportService = reportService;
            _countryService = countryService;
            _cityService = cityService;
        }

        public IActionResult Index(ViewModel viewModel)
        {
            var model = _reportService.GetListJoin(viewModel.Filter);
            viewModel.ReportModel = model;
            viewModel.Hotels = new SelectList(_hotelService.GetList(), "Id", "Name");
            viewModel.Countries = new SelectList(_countryService.GetList(), "Id", "Name");
            viewModel.Cities = new SelectList(_cityService.GetList(), "Id", "Name");
            viewModel.Customers = new SelectList(_customerService.GetList(), "Id", "Name");
            viewModel.Rooms = new SelectList(_roomService.GetList(), "Id", "Name");
            return View(viewModel);
        }
    }
}
