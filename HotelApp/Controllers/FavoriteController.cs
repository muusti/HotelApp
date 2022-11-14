using DataAccess.Models;
using DataAccess.Services.Bases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Security.Claims;

namespace HotelApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly HotelServiceBase _hotelService;

        public FavoriteController(HotelServiceBase hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult AddToFavorite(int hotelId)
        {
            List<FavoriteItemModel> favorite = GetSession();

            string json;
            var hotel = _hotelService.GetItem(hotelId);
            int userId = Convert.ToInt32(User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            FavoriteItemModel item = new FavoriteItemModel()
            {
                HotelId = hotel.Id,
                HotelName = hotel.Name,
                Star = hotel.Star,
                UserId = userId
            };
            favorite.Add(item);
            json = JsonConvert.SerializeObject(favorite);
            HttpContext.Session.SetString("favorite", json);
            TempData["Message"] = hotel.Name + "Added to favorite";
            return RedirectToAction("Index", "Hotels");
        }

        private List<FavoriteItemModel> GetSession()
        {
            List<FavoriteItemModel> favorite = new List<FavoriteItemModel>();
            string json = HttpContext.Session.GetString("favorite");
            if (json != null)
            {
                favorite = JsonConvert.DeserializeObject<List<FavoriteItemModel>>(json);
            }
            return favorite;
        }


        public IActionResult GetFavorite()
        {
            List<FavoriteItemModel> favorite = GetSession().Select(c => new FavoriteItemModel()
            {
                HotelId = c.HotelId,
                HotelName = c.HotelName,
                Star = c.Star,
                UserId = c.UserId

            }).ToList();

            var groupBy = from c in favorite
                          group c by new { c.HotelId, c.UserId, c.HotelName, c.Star }
                          into cGroupBy
                          select new FavoriteItemGroupByModel()
                          {
                              HotelId = cGroupBy.Key.HotelId ?? 0,
                              UserId = cGroupBy.Key.UserId ?? 0,
                              HotelName = cGroupBy.Key.HotelName,
                              HotelCount = cGroupBy.Count(),
                              Star = cGroupBy.Key.Star ?? 0
                          };
            return View(groupBy);

        }

        public IActionResult ClearFavorite()
        {
            var favorite = GetSession();
            int userId = Convert.ToInt32(User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var userFavorite = favorite.Where(c => c.UserId == userId).ToList();

            favorite = favorite.Except(userFavorite).ToList();

            string json = JsonConvert.SerializeObject(favorite);
            HttpContext.Session.SetString("favorite", json);

            return RedirectToAction(nameof(GetFavorite));
        }

        public IActionResult DeleteFromFavorite(int hotelId)
        {
            var favorite = GetSession();
            int userId = Convert.ToInt32(User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var favoriteItem = favorite.FirstOrDefault(c => c.UserId == userId && c.HotelId == hotelId);
            favorite.Remove(favoriteItem);
            string json = JsonConvert.SerializeObject(favorite);
            HttpContext.Session.SetString("favorite", json);

            return RedirectToAction(nameof(GetFavorite));
        }
    }
}
