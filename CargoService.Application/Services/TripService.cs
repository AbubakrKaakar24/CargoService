using AutoMapper;
using CargoService.Application.Common;
using CargoService.Application.DTOs.Trips;
using CargoService.Application.ServiceContracts;
using CargoService.Domain.Entities;
using CargoService.Domain.RepositoryContracts.Base;

namespace CargoService.Application.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TripService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<TripAddDto>> CreateTrip(TripAddDto dto)
        {
            var entity = _mapper.Map<Trip>(dto);
            await _unitOfWork.TripRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<TripAddDto>.SuccessResult(dto);
        }

        public async Task<Result<IEnumerable<TripResponseDto>>> GetAllTrips()
        {
            var trips = await _unitOfWork.TripRepository.GetAll();
            if (trips == null || !trips.Any())
                return Result<IEnumerable<TripResponseDto>>.EmptyResult("trip");

            var dtoList = trips.Select(t => _mapper.Map<TripResponseDto>(t)).ToList();
            return Result<IEnumerable<TripResponseDto>>.SuccessResult(dtoList);
        }

        public async Task<Result<TripResponseDto>> GetTrip(int id)
        {
            var entity = await _unitOfWork.TripRepository.GetById(id);
            if (entity == null)
                return Result<TripResponseDto>.NotFoundResult(id);

            return Result<TripResponseDto>.SuccessResult(_mapper.Map<TripResponseDto>(entity));
        }

        public async Task<Result<TripResponseDto>> DeleteTrip(int id)
        {
            var entity = await _unitOfWork.TripRepository.GetById(id);
            if (entity == null)
                return Result<TripResponseDto>.NotFoundResult(id);

            await _unitOfWork.TripRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<TripResponseDto>.SuccessResult(_mapper.Map<TripResponseDto>(entity));
        }

        public async Task<Result<TripResponseDto>> UpdateTrip(int id, TripAddDto tripAddDto)
        {
            var entity = await _unitOfWork.TripRepository.GetById(id);
            if (entity == null)
                return Result<TripResponseDto>.NotFoundResult(id);

            _mapper.Map(tripAddDto, entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<TripResponseDto>.SuccessResult(_mapper.Map<TripResponseDto>(entity));
        }
    }
}
