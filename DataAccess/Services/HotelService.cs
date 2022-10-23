using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services
{
    public class HotelService : HotelServiceBase
    {
        public HotelService(Db db) : base(db)
        {

        }

        public override IQueryable<Hotel> Query()
        {
            return base.Query()
                .Include(c => c.Country)
                .Include(c => c.City)
                .OrderBy(h => h.Star)
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
                    Country = h.Country
                });
        }

        public override Result Add(Hotel entity, bool save = true)
        {
            if (Query().Any(h => h.Name.ToLower() == entity.Name.ToLower().Trim()))
                return new ErrorResult("The Name You entered exists");


            entity.Name = entity.Name.Trim();

            var result = base.Add(entity, save);
            if (result.IsSuccessful)
                result.Message = "Product added succesfully";
            return result;
        }


    }
}
