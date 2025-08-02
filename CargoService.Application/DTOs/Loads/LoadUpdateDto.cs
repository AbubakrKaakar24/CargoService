using CargoService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Loads
{
    public class LoadUpdateDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string CargoType { get; set; }
        public int Weight { get; set; }
        public DateTime PickupTime { get; set; }
        public string PricingMode { get; set; }
        public LoadStatus LoadStatus { get; set; }
    }
}
