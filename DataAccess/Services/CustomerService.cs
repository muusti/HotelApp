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
                 .Include(c => c.CustomerDetails)
                 .Include(c => c.CustomerHotels)
                 .Include(c => c.CustomerRoom)
                 .Select(c => new Customer()
                 {
                     NameDisplay = c.Name,
                     LastNameDisplay = c.LastName,
                     CustomerRoom = c.CustomerRoom,
                     DateOfBirthDisplay = c.DateOfBirth.Value.ToString("MM/dd/yyyy"),
                     
                     CustomerDetails = new CustomerDetails()
                     {
                         AddressDisplay = c.CustomerDetails.Address,
                         EmailDisplay = c.CustomerDetails.Email,
                         IdentificationNoDisplay = c.CustomerDetails.IdentificationNo,
                         PhoneNumberDisplay = c.CustomerDetails.PhoneNumber,
                         Country = c.CustomerDetails.Country,
                         City = c.CustomerDetails.City
                     },
                     GenderDisplay = c.Gender
                 });
        }

        public override Result Add(Customer entity, bool save = true)
        {
            if (Query().Any(c => c.CustomerDetails.IdentificationNo == entity.CustomerDetails.IdentificationNo))
                return new ErrorResult("Error");

            entity.CustomerDetails = new CustomerDetails()
            {
                CustomerId = entity.Id,
                IdentificationNo = entity.CustomerDetails.IdentificationNo,
                Email = entity.CustomerDetails.Email,
                PhoneNumber = entity.CustomerDetails.PhoneNumber,
                CityId = entity.CustomerDetails.CityId,
                CountryId = entity.CustomerDetails.CountryId,
                Address = entity.CustomerDetails.Address,
                Customer = entity.CustomerDetails.Customer,
                City = entity.CustomerDetails.City,
                Country = entity.CustomerDetails.Country
            };

            return base.Add(entity, save);
        }
    }
}
