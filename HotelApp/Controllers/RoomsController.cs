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
using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Enums;

namespace HotelApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomServiceBase _roomService;
        private readonly HotelServiceBase _hotelService;


        public RoomsController(RoomServiceBase roomService, HotelServiceBase hotelService)
        {
            _roomService = roomService;
            _hotelService = hotelService;
        }

      

        public IActionResult Index()
        {
            List<Room> roomList = _roomService.GetList();
            return View(roomList);
        }
      

        public IActionResult Details(int id)
        {
            Room room = _roomService.GetItem(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_hotelService.GetList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                var result = _roomService.Add(room);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetList(), "Id", "Name", room.HotelId);
            return View(room);
        }

        public IActionResult GetJson(int hotelId)
        {
            var rooms = _roomService.GetList(c => c.HotelId == hotelId);
            return Json(rooms);
        }

        public IActionResult Edit(int id)
        {
            Room room = _roomService.GetItem(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetList(), "Id", "Name", room.HotelId);
            return View(room);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                Result result = _roomService.Update(room);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            ViewData["HotelId"] = new SelectList(_hotelService.GetList(), "Id", "Name", room.HotelId);
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            var result = _roomService.Delete(r => r.Id == id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}
