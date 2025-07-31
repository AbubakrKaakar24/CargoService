using CargoService.Application.Common;  // assuming Result<T> is here
using CargoService.Application.DTOs.Fleets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoService.Application.ServiceContracts
{
    public interface IFleetService
    {
        Task<Result<FleetAddDto>> CreateFleet(FleetAddDto fleetAddDto);
        Task<Result<FleetResponseDto>> UpdateFleet(int id, FleetAddDto fleetAddDto);
        Task<Result<FleetResponseDto>> DeleteFleet(int id);
        Task<Result<FleetResponseDto>> GetFleet(int id);
        Task<Result<IEnumerable<FleetResponseDto>>> GetAllFleets();
    }
}

