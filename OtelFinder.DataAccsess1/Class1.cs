using OtelFinder.entities;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OtelFinder.dataacsees
{
    public class Hoteldbcontext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=10.0.90.13; Database=HotelDb;user id=postgres;Password=profen2016;");

        }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
