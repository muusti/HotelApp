using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Authorization;

namespace HotelApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class CustomersController : Controller
    {
        private readonly CustomerServiceBase _customerService;
        private readonly HotelServiceBase _hotelService;
        private readonly RoomServiceBase _roomService;
        private readonly CountryServiceBase _countryService;
        private readonly CityServiceBase _cityService;



        public CustomersController(CustomerServiceBase customerService, HotelServiceBase hotelService, RoomServiceBase roomService, CountryServiceBase countryService, CityServiceBase cityService)
        {
            _customerService = customerService;
            _hotelService = hotelService;
            _roomService = roomService;
            _countryService = countryService;
            _cityService = cityService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Customer> customerList = _customerService.GetList();
            return View(customerList);
        }

        public IActionResult Details(int id)
        {
            Customer customer = _customerService.GetItem(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {

            ViewBag.Hotels = new SelectList(_hotelService.GetList(), "Id", "Name");
            ViewBag.Rooms = new SelectList(_roomService.GetList(r => r.IsEmpty == true), "Id", "RoomNo");
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name");
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var result = _customerService.Add(customer);

                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name", customer.CountryId);
            ViewBag.Cities = new SelectList(_cityService.GetList(c => c.CountryId == customer.CountryId), "Id", "Name", customer.CityId);
            ViewBag.Rooms = new SelectList(_roomService.GetList(r => r.IsEmpty == true), "Id", "RoomNo", customer.RoomIds);
            ViewBag.Hotels = new SelectList(_hotelService.GetList(), "Id", "Name");
            return View(customer);
        }


        public IActionResult Edit(int id)
        {
            Customer customer = _customerService.GetItem(id);
            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.Hotels = new SelectList(_hotelService.GetList(), "Id", "Name");
            ViewBag.Rooms = new SelectList(_roomService.GetList(r => r.IsEmpty == true), "Id", "RoomNo");
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name");
         
            return View(customer);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var result = _customerService.Update(customer);
                if (result.IsSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Hotels = new SelectList(_hotelService.GetList(), "Id", "Name");
            ViewBag.Rooms = new SelectList(_roomService.GetList(r => r.IsEmpty == true), "Id", "RoomNo");
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name");

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(c => c.Id == id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

        // POST: Customers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
    }
}
