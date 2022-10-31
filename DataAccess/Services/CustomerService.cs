using AppCore.DataAccsess.Results;
using AppCore.DataAccsess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CustomerService : CustomerServiceBase
    {

        public CustomerService(Db db) : base(db)
        {

        }

        public override IQueryable<Customer> Query()
        {
            return base.Query()
                .Include(c => c.CustomerRoom)
                 .Select(c => new Customer()
                 {
                     Id = c.Id,
                     NameDisplay = c.Name,
                     LastNameDisplay = c.LastName,
                     NameAndSurName = c.Name + " " + c.LastName.ToUpper(),
                     DateOfBirthDisplay = c.DateOfBirth.Value.ToString("MM/dd/yyyy"),
                     City = c.City,
                     Country = c.Country,
                     CityId = c.CityId,
                     CountryId = c.CountryId,
                     AddressDisplay = c.Address,
                     EmailDisplay = c.Email,
                     IdentificationNoDisplay = c.IdentificationNo,
                     PhoneNumberDisplay = c.PhoneNumber,
                     GenderDisplay = c.Gender.ToString(),
                     CustomerRoomRoomNoDisplay = string.Join(" ", c.CustomerRoom.Select(cr => cr.Room.RoomNo)),
                     CustomerRoomHotelNameDisplay = string.Join(" ", c.CustomerRoom.Select(cr => cr.Room.Hotel.Name)),
                     RoomIds = c.CustomerRoom.Select(cr => cr.Room.Id).ToList(),
                     HotelIds = c.CustomerRoom.Select(cr => cr.Room.Hotel.Id).ToList(),
                     DateOfEntryDisplay = string.Join(" ", c.CustomerRoom.Select(cr => cr.DateOfEntry.Value.ToString("MM/dd/yyyy"))),
                     ReleaseDateDisplay = string.Join(" ", c.CustomerRoom.Select(cr => cr.ReleaseDate.Value.ToString("MM/dd/yyyy")))
                 });

        }
        public override Result Add(Customer entity, bool save = true)
        {
            entity.Name = entity.Name?.Trim();
            entity.LastName = entity.LastName?.Trim();
            entity.Address = entity.Address?.Trim();

            entity.CustomerRoom = entity.RoomIds?.Select(rId => new CustomerRoom()
            {
                RoomId = rId,
                DateOfEntry = entity.DateOfEntryDisplay2,
                ReleaseDate = entity.ReleaseDateDisplay2

            }).ToList();
            return base.Add(entity, save);
        }
    }
}
