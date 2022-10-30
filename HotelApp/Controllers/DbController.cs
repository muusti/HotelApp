using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            _db.UserDetails.RemoveRange(_db.UserDetails.ToList());

            _db.Users.RemoveRange(_db.Users.ToList());

            _db.Roles.RemoveRange(_db.Roles.ToList());
            _db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Roles', RESEED, 0)");


            _db.Countries.Add(new Country()
            {

                Name = "Türkiye",
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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
                CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
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

            _db.Roles.Add(new Role()
            {
                Name = "admin",
            });
            _db.SaveChanges();

            _db.Roles.Add(new Role()
            {
                Name = "user",
                Users = new List<User>()
                {
                   new User()
                   {
                       UserName = "musti2",
                       Password = "musti2",
                       IsActive = true,
                       UserDetails = new UserDetails()
                       {
                           Email = "mm@m",
                           Gender = Gender.Male,
                           CountryId = _db.Countries.SingleOrDefault(c=>c.Name == "Türkiye").Id,
                           CityId = _db.Cities.SingleOrDefault(c=> c.Name == "Ankara").Id,
                           Address = "aaaaa"
                       }

                   }
                }
            });



            _db.Users.Add(new User()
            {
                UserName = "musti",
                Password = "musti",
                UserDetails = new UserDetails()
                {
                    Email = "m@m",
                    CountryId = _db.Countries.SingleOrDefault(c => c.Name == "Türkiye").Id,
                    CityId = _db.Cities.SingleOrDefault(c => c.Name == "Ankara").Id,
                    Address = "aaaaaaaaa",
                    Gender = Gender.Male
                },
                IsActive = true,
                RoleId = _db.Roles.SingleOrDefault(r => r.Name == "admin").Id

            });

            _db.SaveChanges();
            return Content("<label style=\"color: green;\"><h1>Database seed successful.</h1></label>", "text/html");
        }
    }
}

