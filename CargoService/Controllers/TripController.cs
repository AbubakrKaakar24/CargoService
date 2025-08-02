using CargoService.API.Controllers.Base;
using CargoService.Application.DTOs.Trips;
using CargoService.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : BaseAPIcontroller
    {
        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpPost]
        public async Task<ActionResult<TripAddDto>> CreateTrip([FromBody] TripAddDto dto) => HandleResultResponse(
            await _tripService.CreateTrip(dto)
            );
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripResponseDto>>> GetAllTrips() => HandleResultResponse(
            await _tripService.GetAllTrips()
            );
        [HttpGet("{id}")]
        public async Task<ActionResult<TripResponseDto>> GetTrip(int id) => HandleResultResponse(
            await _tripService.GetTrip(id)
            );
        [HttpPut("{id}")]
        public async Task<ActionResult<TripResponseDto>> UpdateTrip(int id, [FromBody] TripAddDto dto) => HandleResultResponse(
            await _tripService.UpdateTrip(id, dto)
            );
        [HttpDelete("{id}")]
        public async Task<ActionResult<TripResponseDto>> DeleteTrip(int id) => HandleResultResponse(
            await _tripService.DeleteTrip(id)
            );
    }
}
