﻿using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services
{
    public class RoomService : RoomServiceBase
    {
        public RoomService(Db db) : base(db)
        {
        }

        public override IQueryable<Room> Query()
        {
            return base.Query()
                .Include(r => r.Hotel)
                .Include(r => r.RoomFeatures)
                .OrderBy(r => r.Hotel.Name)
                .ThenBy(r => r.RoomNo)
                .Select(r => new Room()
                {
                    Id = r.Id,
                    RoomNo = r.RoomNo,
                    DailyPriceDisplay = r.DailyPrice != null ? r.DailyPrice.Value.ToString("C2") : "",
                    RoomFeatures = r.RoomFeatures,
                    HotelId = r.HotelId,
                    IsEmptyDisplay = r.IsEmpty ? "Empty" : "Not Empty",
                    Hotel = r.Hotel,
                    WeeklyPriceDisplay = r.DailyPrice != null ? (r.DailyPrice * 6).Value.ToString("C2") : "",
                });
        }

        public override Result Add(Room entity, bool save = true)
        {
            if (Query().Any(r => r.RoomNo == entity.RoomNo && r.HotelId == entity.HotelId))
                return new ErrorResult("Room with same name exists");
            return base.Add(entity, save);
        }
    }
}