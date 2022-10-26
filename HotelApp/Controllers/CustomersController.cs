﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;

namespace HotelApp.Controllers
{
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

        public IActionResult Create()
        {

            ViewBag.Hotels = new SelectList(_hotelService.GetList(), "Id", "Name");
            ViewBag.Rooms = new SelectList(_roomService.GetList(r=>r.IsEmpty == true), "Id", "RoomNo");
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name");
            return View();
        }


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
            ViewBag.Cities = new SelectList(_cityService.GetList(c=> c.CountryId == customer.CountryId), "Id", "Name", customer.CityId);
            ViewBag.Rooms = new SelectList(_roomService.GetList()/*Query().Where(r => r.IsEmptyDisplay == "Empty").ToList()*/, "Id", "RoomNo", customer.RoomIds);
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
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int id)
        {
            Customer customer = null; // TODO: Add get item service logic here
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
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
