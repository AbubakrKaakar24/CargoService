using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Bids
{
    public class BidUpdateDto
    {
        public int? LoadId { get; set; }
        public int? FleetId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? BidTime { get; set; }
    }
}
