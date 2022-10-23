#nullable disable

using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public Db(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFeatures> RoomsFeatures { get; set; }
        public DbSet<CustomerRoom> CustomerRooms { get; set; }
        public DbSet<CustomerHotel> CustomerHotel { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerHotel>()
                .HasKey(cr => new { cr.CustomerId, cr.HotelId });

            modelBuilder.Entity<CustomerRoom>()
            .HasKey(cr => new { cr.CustomerId, cr.RoomId });

            modelBuilder.Entity<CustomerDetails>()
                .HasOne(c => c.Customer)
                .WithOne(c => c.CustomerDetails)
                .HasForeignKey<CustomerDetails>(c => c.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoomFeatures>()
                .HasOne(r => r.Room)
                .WithOne(r => r.RoomFeatures)
                .HasForeignKey<RoomFeatures>(r => r.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomerDetails>()
                .HasOne(cd => cd.Country)
                .WithMany(c => c.CustomerDetails)
                .HasForeignKey(cd => cd.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomerDetails>()
                .HasOne(cd => cd.City)
                .WithMany(c => c.CustomerDetails)
                .HasForeignKey(cd => cd.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Country)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.City)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CityId)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
