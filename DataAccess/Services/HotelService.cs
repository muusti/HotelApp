﻿using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
                result.Message = "Hotel added succesfully";
            return result;
        }

        public override Result Delete(Expression<Func<Hotel, bool>> predicate, bool save = true)
        {
            var hotel = Query().SingleOrDefault(predicate);
            var rooms = _roomService.GetList(r => r.HotelId == hotel.Id);
            var roomFeatures = rooms.Select(r => r.RoomFeatures);

            _dbContext.Set<RoomFeatures>().RemoveRange(roomFeatures);
            _dbContext.Set<Room>().RemoveRange(hotel.Rooms);

            return base.Delete(predicate, save);

        }

        public override Result Delete(Hotel entity, bool save = true)
        {
            var rooms = _roomService.GetList(r => r.HotelId == entity.Id);
            var roomFeatures = rooms.Select(r => r.RoomFeatures);

            _dbContext.Entry<Hotel>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _dbContext.Set<RoomFeatures>().RemoveRange(roomFeatures);
            _dbContext.Set<Room>().RemoveRange(entity.Rooms);

            return base.Delete(entity, save);
        }

    }
}
