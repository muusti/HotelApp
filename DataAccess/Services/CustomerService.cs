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
                .OrderBy(c=> c.Name)
                 .Select(c => new Customer()
                 {
                     Id = c.Id,
                     Name = c.Name,
                     LastName = c.LastName,
                     DateOfBirth = c.DateOfBirth,
                     NameAndSurName = c.Name + " " + c.LastName.ToUpper(),
                     DateOfBirthDisplay = c.DateOfBirth.Value.ToString("MM/dd/yyyy"),
                     City = c.City,
                     Country = c.Country,
                     CityId = c.CityId,
                     CountryId = c.CountryId,
                     Address = c.Address,
                     Email = c.Email,
                     IdentificationNo = c.IdentificationNo,
                     PhoneNumber = c.PhoneNumber,
                     Gender = c.Gender,
                     CustomerRoom = c.CustomerRoom,
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
            if (Query().Any(c => c.IdentificationNo == entity.IdentificationNo.Trim() && c.Id != entity.Id))
                return new ErrorResult("The Identification No you entered exists");

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

        public override Result Update(Customer entity, bool save = true)
        {
            if (Query().Any(c => c.IdentificationNo == entity.IdentificationNo.Trim() && c.Id != entity.Id))
                return new ErrorResult("The Identification No you entered exists");

            var customer = Query().SingleOrDefault(c => c.Id == entity.Id);
            _dbContext.Set<CustomerRoom>().RemoveRange(customer.CustomerRoom);

            entity.CustomerRoom = entity.RoomIds?.Select(rId => new CustomerRoom()
            {
                RoomId = rId,
                DateOfEntry = entity.DateOfEntryDisplay2,
                ReleaseDate = entity.ReleaseDateDisplay2
            }).ToList();

            return base.Update(entity, save);
        }
    }
}
