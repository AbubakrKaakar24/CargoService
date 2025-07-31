using CargoService.Application.Common;
using CargoService.Application.DTOs.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.ServiceContracts
{
    public interface IBidService
    {
        public Task<Result<BidAddDto>> CreateBid(BidAddDto bidAddDto);
        public Task<Result<BidResponseDto>> UpdateBid(int id, BidAddDto bidAddDto) ;
        public Task<Result<BidResponseDto>> DeleteBid(int id);
        public Task<Result<BidResponseDto>> GetBid(int id);
        public Task<Result<IEnumerable<BidResponseDto>>> GetAllBids();

    }
}
