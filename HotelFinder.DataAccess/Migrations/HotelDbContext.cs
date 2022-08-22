
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
   public class HotelDbContext:DbContext
    {
        public HotelDbContext()
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("Server=10.0.90.13; Database=HotelDb;user id=postgres;Password=profen2016;");

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
