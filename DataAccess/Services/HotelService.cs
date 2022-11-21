using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using AppCore.Utils;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DataAccess.Services
{
    public class HotelService : HotelServiceBase
    {
        private readonly RoomServiceBase _roomService;

        public HotelService(Db db, RoomServiceBase roomService) : base(db)
        {
            _roomService = roomService;
        }

        public override IQueryable<Hotel> Query()
        {
            return base.Query()
                .Include(h => h.Country)
                .Include(h => h.City)
                .Include(h => h.Rooms)
                .ThenInclude(r => r.RoomFeatures)
                .OrderByDescending(h => h.Star)
                .ThenByDescending(h => h.Name)
                .Select(h => new Hotel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    CityId = h.CityId,
                    Star = h.Star,
                    CountryId = h.CountryId,
                    Rooms = h.Rooms,
                    City = h.City,
                    Country = h.Country,
                    Image = h.Image,
                    ImageExtension = h.ImageExtension,
                    ImageTagSrcDisplay = h.Image != null ? FileUtil.GetContentType(h.ImageExtension, true, true) + Convert.ToBase64String(h.Image) : null
                });
        }

        public override Result Add(Hotel entity, bool save = true)
        {
            if (Query().Any(h => h.Name.ToLower() == entity.Name.ToLower().Trim()))
                return new ErrorResult("The Name You entered exists");

            entity.Name = entity.Name.Trim();

            var result = base.Add(entity, save);
            if (result.IsSuccessful)
                result.Message = "Hotel added succesfully";

            return result;
        }

        public override Result Update(Hotel entity, bool save = true)
        {
            var hotel = Query().SingleOrDefault(h => h.Id == entity.Id);
            if (entity.Image == null)
            {
                entity.Image = hotel.Image;
                entity.ImageExtension = hotel.ImageExtension;
            }

            return base.Update(entity, save);
        }

        public override Result Delete(Expression<Func<Hotel, bool>> predicate, bool save = true)
        {
            var hotel = Query().SingleOrDefault(predicate);

            if (hotel.Rooms.Count > 0 && hotel.Rooms != null)
                RoomsDelete(hotel.Rooms.ToList());

            return base.Delete(predicate, save);
        }

        private void RoomsDelete(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                _roomService.Delete(room, false);
            }
            Save();

        }

    }
}
