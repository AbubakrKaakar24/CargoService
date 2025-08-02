using CargoService.Domain.Entities;
using CargoService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Trips
{
    public class TripAddDto
    {
        public int LoadId { get; set; }
        public int DriverId { get; set; }
        public TripStatus tripStatus { get; set; }
        public DateTime StartTime { get; set; }
    }
}
