using CargoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Bids
{
    public class BidResponseDto
    {   
        public int Id { get; set; }
        public int LoadId { get; set; }
        public string FleetId { get; set; }
        public decimal Price { get; set; }
        public DateTime BidTime { get; set; }

        public virtual Load? Load { get; set; }
        public virtual Fleet? Fleet { get; set; }
    }
}
