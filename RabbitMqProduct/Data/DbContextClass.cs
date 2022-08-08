using Microsoft.EntityFrameworkCore;
using RabbitMqProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqProduct.Data
{
    public class DbContextClass: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=10.0.90.13; Database=ProductDb;user id=postgres;Password=profen2016;");

        }
        public DbSet<Product> Products { get; set; }
       
}
   

    }

