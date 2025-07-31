using CargoService.API.Controllers.Base;
using CargoService.Application.DTOs.Bids;
using CargoService.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : BaseAPIcontroller
    {
        private readonly IBidService _bidService;
        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidResponseDto>>> GetAllBids()=> HandleResultResponse(await _bidService.GetAllBids());

        [HttpGet("id")]
        public async Task<ActionResult<BidResponseDto>> GetBid(int id) => HandleResultResponse(await _bidService.GetBid(id));

        [HttpPost]
        public async Task<ActionResult<BidAddDto>> CreateBid([FromBody] BidAddDto bidAddDto) => HandleResultResponse(await _bidService.CreateBid(bidAddDto));

        [HttpPut("id")]
        public async Task<Action>
    }
}
