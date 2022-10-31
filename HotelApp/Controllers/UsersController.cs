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

namespace HotelApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserServiceBase _userService;
        private readonly RoleServiceBase _roleService;
        private readonly CountryServiceBase _countryService;
        private readonly CityServiceBase _cityService;

        public UsersController(UserServiceBase userService, RoleServiceBase roleService,CountryServiceBase countryService, CityServiceBase cityService)
        {
            _userService = userService;
            _roleService = roleService;
            _countryService = countryService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            List<User> userList = _userService.GetList();
            return View(userList);
        }

        public IActionResult Details(int id)
        {
            User user = _userService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_roleService.GetList(), "Id", "Name");
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Add(user);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            ViewData["RoleId"] = new SelectList(_roleService.GetList(), "Id", "Name", user.RoleId);
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name",user.UserDetails.CountryId);
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name", user.UserDetails.CountryId);

            return View(user);
        }

        public IActionResult Edit(int id)
        {
            User user = _userService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_roleService.GetList(), "Id", "Name", user.RoleId);
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name",user.UserDetails.CountryId);
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name",user.UserDetails.CityId);
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Update(user);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewData["RoleId"] = new SelectList(_roleService.GetList(), "Id", "Name", user.RoleId);
            ViewBag.Countries = new SelectList(_countryService.GetList(), "Id", "Name", user.UserDetails.CountryId);
            ViewBag.Cities = new SelectList(_cityService.GetList(), "Id", "Name", user.UserDetails.CityId);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            User user = _userService.GetItem(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _userService.Delete(u => u.Id == id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
