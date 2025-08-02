using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Domain.Entities
{
    public  class Bid
    {
        [Key]
        public int Id { get; set; }
        public  int LoadId { get; set; }
        public int FleetId { get; set; }
        public decimal Price { get; set; }
        public DateTime BidTime { get; set; }
        
        public virtual Load? Load { get; set; }
        public virtual Fleet? Fleet { get; set; }
    }
}
