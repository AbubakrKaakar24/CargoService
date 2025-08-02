using CargoService.API.Controllers.Base;
using CargoService.Application.DTOs.Fleets;
using CargoService.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetController :BaseAPIcontroller
    {   
        private readonly IFleetService _fleetService;
        public FleetController(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }
        [HttpPost]
        public async Task<ActionResult<FleetAddDto>> CreateFleet([FromBody] FleetAddDto dto)
        => HandleResultResponse(await _fleetService.CreateFleet(dto));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FleetResponseDto>>> GetAllFleets()
       => HandleResultResponse(await _fleetService.GetAllFleets());
        [HttpGet("{id}")]
        public async Task<ActionResult<FleetResponseDto>> GetFleet(int id)
        => HandleResultResponse(await _fleetService.GetFleet(id));
        [HttpPut("id")]
        public async Task<ActionResult<FleetResponseDto>> UpdateFleet(int id,[FromBody] FleetAddDto dto)
        => HandleResultResponse(await _fleetService.UpdateFleet(id,dto));
        [HttpDelete("{id}")]
        public async Task<ActionResult<FleetResponseDto>> DeleteFleet(int id)
        => HandleResultResponse(await _fleetService.DeleteFleet(id));


    }
}
