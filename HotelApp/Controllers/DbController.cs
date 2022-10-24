using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class DbController : Controller
    {
        private readonly Db _db;
        public DbController(Db db)
        {
            _db = db;
        }

        public IActionResult Seed()
        {

            var city = _db.Cities.ToList();
            _db.Cities.RemoveRange(city);

            var country = _db.Countries.ToList();
            _db.Countries.RemoveRange(country);

            var roomFeatures = _db.RoomsFeatures.ToList();
            _db.RoomsFeatures.RemoveRange(roomFeatures);

            var room = _db.Rooms.ToList();
            _db.Rooms.RemoveRange(room);

            var hotels = _db.Hotels.ToList();
            _db.Hotels.RemoveRange(hotels);

            var customer = _db.Customers.ToList();
            _db.Customers.RemoveRange(customer);


            _db.Countries.Add(new Country()
            {

                Name = "Turkiye",
                Cities = new List<City>()
               {
                   new City()
                   {
                       Name = "İstanbul"

                   },
                   new City()
                   {
                       Name = "Ankara"

                   },
                   new City()
                   {
                       Name = "Antalya"

                   },
                   new City()
                   {
                       Name = "Muğla"

                   },

               }

            });

            _db.Countries.Add(new Country()
            {

                Name = "Germany",
                Cities = new List<City>()
               {
                   new City()
                   {
                       Name = "Berlin"

                   }

               }

            });

            _db.SaveChanges();

            _db.Hotels.Add(new Hotel()
            {
                Name = "HotelA",
                Star = 5,
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "Antalya").Id,
                Rooms = new List<Room>(){
                    new Room()
                    {
                        RoomNo = 300,
                        IsEmpty = true,
                        DailyPrice = 25,
                        RoomFeatures =   new RoomFeatures()
                        {
                             m2 = 20,
                             RoomType = RoomType.Basic,

                        }
                    },

                     new Room()
                    {
                        RoomNo = 200,
                        IsEmpty = true,
                        DailyPrice = 25,
                        RoomFeatures= new RoomFeatures()
                        {
                            m2 = 50,
                            RoomType= RoomType.Standart
                        }

                    },
                        new Room()
                    {
                        RoomNo = 250,
                        IsEmpty = true,
                        DailyPrice = 100,
                        RoomFeatures= new RoomFeatures()
                        {
                            m2 = 50,
                            RoomType= RoomType.Lux
                        }

                    }
                }
            });

            _db.Hotels.Add(new Hotel()
            {
                Name = "HotelC",
                Star = 7,
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "Antalya").Id,
                Rooms = new List<Room>(){
                    new Room()
                    {
                        RoomNo = 500,
                        IsEmpty = true,
                        DailyPrice = 125,
                        RoomFeatures =   new RoomFeatures()
                        {
                             m2 = 50,
                             RoomType = RoomType.Standart,

                        }
                    },

                     new Room()
                    {
                        RoomNo = 600,
                        IsEmpty = true,
                        DailyPrice = 150,
                        RoomFeatures= new RoomFeatures()
                        {
                            m2 = 50,
                            RoomType= RoomType.Lux
                        }

                    },
                        new Room()
                    {
                        RoomNo = 150,
                        IsEmpty = true,
                        DailyPrice = 200,
                        RoomFeatures= new RoomFeatures()
                        {
                            m2 = 100,
                            RoomType= RoomType.UltraLuks
                        }

                    }
                }
            });

            _db.Hotels.Add(new Hotel()
            {
                Name = "HotelB",
                Star = 5,
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "İstanbul").Id,
                Rooms = new List<Room>(){
                    new Room()
                    {
                        RoomNo = 1000,
                        IsEmpty = true,
                        DailyPrice = 25,
                        RoomFeatures =   new RoomFeatures()
                        {
                             m2 = 20,
                             RoomType = RoomType.Basic,
                        }
                    },

                     new Room()
                    {
                        RoomNo = 1500,
                        IsEmpty = true,
                        DailyPrice = 25,
                        RoomFeatures= new RoomFeatures()
                        {
                            m2 = 50,
                            RoomType= RoomType.Standart
                        }

                    },
                        new Room()
                    {
                        RoomNo = 2000,
                        IsEmpty = true,
                        DailyPrice = 100,
                        RoomFeatures= new RoomFeatures()
                        {
                            m2 = 50,
                            RoomType= RoomType.Lux
                        }

                    }
                }
            });
            _db.SaveChanges();

            _db.Customers.Add(new Customer()
            {
                Gender = Gender.Male,
                Name = "Aaa",
                LastName = "Bbb",
                DateOfBirth = DateTime.Parse("01/01/1980"),


                Address = "aaaa",
                Email = "aa@",
                PhoneNumber = "000",
                IdentificationNo = "000",
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "Antalya").Id,

                CustomerRoom = new List<CustomerRoom>()
                {
                    new CustomerRoom()
                    {
                        RoomId = _db.Rooms.SingleOrDefault(r => r.RoomNo == 200).Id,
                         DateOfEntry = DateTime.Parse("25/06/2020"),
                         ReleaseDate = DateTime.Parse("30/06/2020")
                    },
                }

            });

            _db.Customers.Add(new Customer()
            {
                Gender = Gender.Male,
                Name = "Bbb",
                LastName = "Aaa",
                DateOfBirth = DateTime.Parse("01/01/1985"),


                Address = "aaaa",
                Email = "aa@",
                PhoneNumber = "000",
                IdentificationNo = "000",
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "İstanbul").Id,

                CustomerRoom = new List<CustomerRoom>()
                {
                    new CustomerRoom()
                    {
                        RoomId = _db.Rooms.SingleOrDefault(r => r.RoomNo == 250).Id,
                         DateOfEntry = DateTime.Parse("01/01/2022"),
                         ReleaseDate = DateTime.Parse("01/01/2022")
                    }
                }
            });

            _db.Customers.Add(new Customer()
            {
                Gender = Gender.Male,
                Name = "EEE",
                LastName = "EEE",
                DateOfBirth = DateTime.Parse("01/01/1990"),


                Address = "aaaa",
                Email = "aa@",
                PhoneNumber = "000",
                IdentificationNo = "000",
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "İstanbul").Id,

                CustomerRoom = new List<CustomerRoom>()
                {
                    new CustomerRoom()
                    {
                        RoomId = _db.Rooms.SingleOrDefault(r => r.RoomNo == 1500).Id,
                         DateOfEntry = DateTime.Parse("01/01/2022"),
                         ReleaseDate = DateTime.Parse("01/01/2022")
                    }
                }

            });

            _db.Customers.Add(new Customer()
            {
                Gender = Gender.Male,
                Name = "FFF",
                LastName = "FFF",
                DateOfBirth = DateTime.Parse("01/01/1995"),


                Address = "FFF",
                Email = "FFF@",
                PhoneNumber = "00000",
                IdentificationNo = "00000",
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Turkiye").Id,
                CityId = _db.Cities.SingleOrDefault(c => c.Name == "İstanbul").Id,

                CustomerRoom = new List<CustomerRoom>()
                {
                    new CustomerRoom()
                    {
                        RoomId = _db.Rooms.SingleOrDefault(r => r.RoomNo == 500).Id,
                         DateOfEntry = DateTime.Parse("01/01/2019"),
                         ReleaseDate = DateTime.Parse("01/01/2019")
                    }
                }

            });

            _db.SaveChanges();
            return Content("<label style=\"color: green;\"><h1>Database seed successful.</h1></label>", "text/html");
        }
    }
}

