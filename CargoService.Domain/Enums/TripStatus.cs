using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Domain.Enums
{
    public enum TripStatus
    {
        Assigned,
        NotStarted,
        InProgress,
        Completed,
        Cancelled,
    }
}
