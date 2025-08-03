using AutoMapper;
using CargoService.Application.Common;
using CargoService.Application.DTOs.Loads;
using CargoService.Application.ServiceContracts;
using CargoService.Domain.Entities;
using CargoService.Domain.Enums;
using CargoService.Domain.RepositoryContracts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CargoService.Application.Services
{
    public class LoadService : ILoadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<LoadAddDto>> CreateLoad(LoadAddDto loadAddDto)
        {
            var entity = _mapper.Map<Load>(loadAddDto);
            await _unitOfWork.LoadRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<LoadAddDto>.SuccessResult(loadAddDto);
        }

        public async Task<Result<LoadResponseDto>> DeleteLoad(int id)
        {
            var entity = await _unitOfWork.LoadRepository.GetById(id);
            if (entity == null)
                return Result<LoadResponseDto>.NotFoundResult(id);

            await _unitOfWork.LoadRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<LoadResponseDto>.SuccessResult(_mapper.Map<LoadResponseDto>(entity));
        }

        public async Task<Result<IEnumerable<LoadResponseDto>>> GetAllLoads()
        {
            var loads = await _unitOfWork.LoadRepository.GetAll();
            if (loads == null || !loads.Any())
                return Result<IEnumerable<LoadResponseDto>>.EmptyResult("load");

            var dtoList = loads.Select(l => _mapper.Map<LoadResponseDto>(l)).ToList();
            return Result<IEnumerable<LoadResponseDto>>.SuccessResult(dtoList);
        }

        public async Task<Result<LoadResponseDto>> GetLoad(int id)
        {
            var entity = await _unitOfWork.LoadRepository.GetById(id);
            if (entity == null)
                return Result<LoadResponseDto>.NotFoundResult(id);

            return Result<LoadResponseDto>.SuccessResult(_mapper.Map<LoadResponseDto>(entity));
        }

        public async Task<Result<LoadResponseDto>> UpdateLoad(int id, LoadUpdateDto dto)
        {
            var entity = await _unitOfWork.LoadRepository.GetById(id);
            if (entity == null)
                return Result<LoadResponseDto>.NotFoundResult(id);

            _mapper.Map(dto, entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<LoadResponseDto>.SuccessResult(_mapper.Map<LoadResponseDto>(entity));
        }

        public async Task<Result<LoadResponseDto>> AcceptLoad(int LoadId)
        {
            var entity = await _unitOfWork.LoadRepository.GetFirstOrDefault(l=>l.Id==LoadId);
            if (entity == null)
                return Result<LoadResponseDto>.NotFoundResult(LoadId);
            if (entity.LoadStatus != LoadStatus.Open)
                return Result<LoadResponseDto>.FailureResult($"Load with ID {LoadId} is not open for accepting.");
            var random = new Random();
            var randomId = random.Next(1, 100);
            var trip = new Trip
            {
                LoadId = entity.Id,
                DriverId = randomId, // Simulating a driver ID, this should be replaced with actual driver ID logic
                tripStatus = TripStatus.NotStarted,
                StartTime = DateTime.UtcNow
            };
            await _unitOfWork.TripRepository.Add(trip);
            entity.LoadStatus = LoadStatus.Assigned;
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<LoadResponseDto>.SuccessResult(_mapper.Map<LoadResponseDto>(entity));
        }
    }
}
