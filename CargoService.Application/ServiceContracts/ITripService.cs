using CargoService.Application.Common;  // for Result<T>
using CargoService.Application.DTOs.Trips;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoService.Application.ServiceContracts
{
    public interface ITripService
    {
        Task<Result<TripAddDto>> CreateTrip(TripAddDto tripAddDto);
        Task<Result<TripResponseDto>> UpdateTrip(int id, TripAddDto tripAddDto);
        Task<Result<TripResponseDto>> DeleteTrip(int id);
        Task<Result<TripResponseDto>> GetTrip(int id);
        Task<Result<IEnumerable<TripResponseDto>>> GetAllTrips();
    }
}
