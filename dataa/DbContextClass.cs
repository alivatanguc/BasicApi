using Microsoft.EntityFrameworkCore;
using RabbitMqOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Data
{
    public class DbContextClass:DbContext
    {
       
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseNpgsql("Server=10.0.90.13; Database=OrderDb;user id=postgres;Password=profen2016;");

            }
            public DbSet<Order> Orders { get; set; }

        }
    }

