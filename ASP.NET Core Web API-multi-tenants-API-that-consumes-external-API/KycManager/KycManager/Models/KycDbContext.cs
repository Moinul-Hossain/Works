using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KycManager.Models
{
    public class KycDbContext : DbContext
    {
        public KycDbContext(DbContextOptions<KycDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasData(
                           new Tenant { Id = Guid.Parse("8d3c63a3-00ab-416d-b152-c0dbcf22df01"), AppName = "App1" },
                           new Tenant { Id = Guid.Parse("e18fb303-f450-4862-b7c1-a78d4445d7a0"), AppName = "App2" }
                         );
        }
    }
}
