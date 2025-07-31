using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.Common
{
    public class ValidationError
    {
       

        public string? Code { get; set; }

        public string? Property { get; set; }

        public string? Description { get; set; } 
        public override string ToString()
        {
            return $"Code: {this.Code}, Property: {this.Property}, Description: {this.Description}";
        }
    }
}
