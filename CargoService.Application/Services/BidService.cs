using AutoMapper;
using CargoService.Application.Common;
using CargoService.Application.DTOs.Bids;
using CargoService.Application.ServiceContracts;
using CargoService.Domain.Entities;
using CargoService.Domain.RepositoryContracts.Base;

namespace CargoService.Application.Services
{
    public class BidService : IBidService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BidService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<BidAddDto>> CreateBid(BidAddDto dto)
        {
            var entity = _mapper.Map<Bid>(dto);
            await _unitOfWork.BidRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<BidAddDto>.SuccessResult(dto);
        }

        public async Task<Result<IEnumerable<BidResponseDto>>> GetAllBids()
        {
            var bids= (await _unitOfWork.BidRepository.GetAll())
                   .Select(_mapper.Map<BidResponseDto>);
            if (bids == null || !bids.Any())
                return Result<IEnumerable<BidResponseDto>>.EmptyResult("Bid");
            return Result<IEnumerable<BidResponseDto>>.SuccessResult(bids);
        }

        public async Task<Result<BidResponseDto>> GetBid(int id)
        {
            var entity = await _unitOfWork.BidRepository.GetById(id);
            if (entity == null)
               return  Result<BidResponseDto>.NotFoundResult(id);
               var bidResponseDto = _mapper.Map<BidResponseDto>(entity);
            return Result<BidResponseDto>.SuccessResult(bidResponseDto);
        }

        public async Task<Result<BidResponseDto>> DeleteBid(int id)
        {
            var entity = await _unitOfWork.BidRepository.GetById(id);
            if (entity == null)
                return Result<BidResponseDto>.NotFoundResult(id);

            await _unitOfWork.BidRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<BidResponseDto>.SuccessResult(_mapper.Map<BidResponseDto>(entity));
        }

        public async Task<Result<BidResponseDto>> UpdateBid(int id, BidAddDto bidAddDto)
        {
           var entity= await _unitOfWork.BidRepository.GetFirstOrDefault(b=> b.Id==id);
            if (entity == null)
                return Result<BidResponseDto>.NotFoundResult(id);
            _mapper.Map(bidAddDto, entity);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return Result<BidResponseDto>.SuccessResult(_mapper.Map<BidResponseDto>(entity));
        }
    }
}
