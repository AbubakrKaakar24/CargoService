using CargoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Fleets
{
    public class FleetAddDto
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<Bid>? Bids { get; set; }
    }
}
