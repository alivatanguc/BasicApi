using Amazon.EC2.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CachePostgre
{
    public class PostgreContext : DbContext
    {
        public PostgreContext() : base(nameOrConnectionString: "PostgreSQL") { }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
