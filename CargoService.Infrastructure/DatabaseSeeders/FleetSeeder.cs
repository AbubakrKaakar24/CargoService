using CargoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Infrastructure.DatabaseSeeders
{
    public class FleetSeeder
    {

        public static void DataSeed(ModelBuilder builder)
        {
            builder.Entity<Fleet>().HasData(
                new Fleet { Id = 1, Email = "abc@example.com", Phone = "+93747627648", Name = "AK" },
                new Fleet { Id = 2, Email = "fleet2@example.com", Phone = "+93712345678", Name = "FastTrans" },
                new Fleet { Id = 3, Email = "contact@cargo3.com", Phone = "+93798765432", Name = "Speedy Movers" },
                new Fleet { Id = 4, Email = "info@fleet4.com", Phone = "+93755566677", Name = "Reliable Fleet" },
                new Fleet { Id = 5, Email = "support@fleet5.com", Phone = "+93711223344", Name = "Express Logistics" }
            );
        }
    }
}
