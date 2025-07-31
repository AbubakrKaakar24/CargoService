using CargoService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int LoadId { get; set; }
        public int DriverId { get; set; }
        public TripStatus tripStatus { get; set; }
        public DateTime StartTime { get; set; }
        public Load? Load { get; set; }


    }
}
