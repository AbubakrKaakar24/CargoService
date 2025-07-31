using AutoMapper;
using CargoService.Application.Common;
using CargoService.Application.DTOs.Fleets;
using CargoService.Application.ServiceContracts;
using CargoService.Domain.Entities;
using CargoService.Domain.RepositoryContracts.Base;


namespace CargoService.Application.Services
{
    public class FleetService : IFleetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FleetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<FleetAddDto>> CreateFleet(FleetAddDto fleetAddDto)
        {
            var entity = _mapper.Map<Fleet>(fleetAddDto);
            await _unitOfWork.FleetRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<FleetAddDto>.SuccessResult(fleetAddDto);
        }

        public async Task<Result<FleetResponseDto>> DeleteFleet(int id)
        {
            var entity = await _unitOfWork.FleetRepository.GetById(id);
            if (entity == null)
            {
               return Result<FleetResponseDto>.NotFoundResult(id);
            }
            await _unitOfWork.FleetRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<FleetResponseDto>.SuccessResult(_mapper.Map<FleetResponseDto>(entity));
        }

        public async Task<Result<IEnumerable<FleetResponseDto>>> GetAllFleets()
        {
            var fleets = await _unitOfWork.FleetRepository.GetAll();
            if (fleets == null || !fleets.Any())
            {
                return Result<IEnumerable<FleetResponseDto>>.EmptyResult("fleet");
            }
            return Result<IEnumerable<FleetResponseDto>>.SuccessResult((await _unitOfWork.FleetRepository.GetAll())
                .Select(f => _mapper.Map<FleetResponseDto>(f))
                .ToList());

        }

        public async Task<Result<FleetResponseDto>> GetFleet(int id)
        {
            var entity = await _unitOfWork.FleetRepository.GetById(id);
            if (entity == null)
            {
                return Result<FleetResponseDto>.NotFoundResult(id);
            }
            return Result<FleetResponseDto>.SuccessResult(_mapper.Map<FleetResponseDto>(entity));

        }

        public async Task<Result<FleetResponseDto>> UpdateFleet(int id, FleetAddDto fleetAddDto)
        {
            var entity = await _unitOfWork.FleetRepository.GetFirstOrDefault(f=> f.Id==id);
            if (entity == null)
            {
                return Result<FleetResponseDto>.NotFoundResult(id);
            }
            _mapper.Map(fleetAddDto, entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<FleetResponseDto>.SuccessResult(_mapper.Map<FleetResponseDto>(entity));
        }
    }
}
