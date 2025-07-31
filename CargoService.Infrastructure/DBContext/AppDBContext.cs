using CargoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Infrastructure.DBContext
{
    public class AppDBContext:DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       public DbSet<Load> Loads { get; set; }
       public DbSet<Bid> bids { get; set; }
       public DbSet<Fleet> Fleets { get; set; }
       public DbSet<Trip> Trips { get; set; }

    }
}
