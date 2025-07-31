using CargoService.Application.Common;  // for Result<T>
using CargoService.Application.DTOs.Loads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoService.Application.ServiceContracts
{
    public interface ILoadService
    {
        Task<Result<LoadAddDto>> CreateLoad(LoadAddDto loadAddDto);
        Task<Result<LoadResponseDto>> UpdateLoad(int id, LoadAddDto loadAddDto);
        Task<Result<LoadResponseDto>> DeleteLoad(int id);
        Task<Result<LoadResponseDto>> GetLoad(int id);
        Task<Result<IEnumerable<LoadResponseDto>>> GetAllLoads();
    }
}
