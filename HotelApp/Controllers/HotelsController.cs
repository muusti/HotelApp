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
using NuGet.Common;
using AppCore.Utils;
using HotelApp.Settings;

namespace HotelApp.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelServiceBase _hotelService;
        private readonly CountryServiceBase _countryService;
        private readonly CityServiceBase _cityService;


        public HotelsController(HotelServiceBase hotelService, CountryServiceBase countryService, CityServiceBase cityService)
        {
            _hotelService = hotelService;
            _countryService = countryService;
            _cityService = cityService;
        }


        public IActionResult Index()
        {
            List<Hotel> hotelList = _hotelService.GetList();
            return View(hotelList);
        }


        public IActionResult Details(int id)
        {
            Hotel hotel = _hotelService.GetItem(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_cityService.GetList(), "Id", "Name");
            ViewData["CountryId"] = new SelectList(_countryService.GetList(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel, IFormFile? hotelImage)
        {
            if (ModelState.IsValid)
            {
                var updateResult = UpdateImage(hotel, hotelImage);
                if (updateResult == false)
                    ModelState.AddModelError("", "File extension and length are you valid");

                else
                {

                    var result = _hotelService.Add(hotel);

                    if (result.IsSuccessful)
                    {
                        TempData["Message"] = result.Message;
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", result.Message);
                }
            }

            ViewData["CityId"] = new SelectList(_cityService.GetList(), "Id", "Name", hotel.CityId);
            ViewData["CountryId"] = new SelectList(_countryService.GetList(), "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        private bool? UpdateImage(Hotel entity, IFormFile uploadedFile)
        {
            bool? result = null;
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                result = FileUtil.CheckFileExtension(uploadedFile.FileName, AppSettings.FileExtensions).IsSuccessful;
                if (result == true)
                {
                    result = FileUtil.CheckFileLength(uploadedFile.Length, AppSettings.FileLength).IsSuccessful;
                }
            }

            if (result == true)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    uploadedFile.CopyTo(memoryStream);
                    entity.Image = memoryStream.ToArray();
                    entity.ImageExtension = Path.GetExtension(uploadedFile.FileName);
                }
            }

            return result;
        }


        public IActionResult Edit(int id)
        {
            Hotel hotel = _hotelService.GetItem(id);

            if (hotel == null)
            {
                return NotFound();
            }

            ViewData["CityId"] = new SelectList(_cityService.GetList(), "Id", "Name", hotel.CityId);
            ViewData["CountryId"] = new SelectList(_countryService.GetList(), "Id", "Name", hotel.CountryId);
            return View(hotel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hotel hotel, IFormFile? hotelImage)
        {

            if (ModelState.IsValid)
            {
                var updateResult = UpdateImage(hotel, hotelImage);
                if (updateResult == false)
                {
                    ModelState.AddModelError("", "File extension and length are you valid");
                }
                else
                {
                    var result = _hotelService.Update(hotel);
                    if (result.IsSuccessful)
                    {
                        TempData["Message"] = result.Message;
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", result.Message);
                }
            }

            ViewData["CityId"] = new SelectList(_cityService.GetList(), "Id", "Name", hotel.CityId);
            ViewData["CountryId"] = new SelectList(_countryService.GetList(), "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        public IActionResult Delete(int id)
        {
            var result = _hotelService.Delete(h => h.Id == id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteImage(int id)
        {
            _hotelService.DeleteImage(id);
            return RedirectToAction(nameof(Details), new { id });
        }

    }
}
