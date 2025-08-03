using CargoService.API.Controllers.Base;
using CargoService.Application.DTOs.Loads;
using CargoService.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadController : BaseAPIcontroller
    {
        private readonly ILoadService _loadService;
        public LoadController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        [HttpPost]
        public async Task<ActionResult<LoadAddDto>> CreateLoad([FromBody] LoadAddDto dto) => HandleResultResponse(
            await _loadService.CreateLoad(dto)
            );

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoadResponseDto>>> GetAllLoads() => HandleResultResponse(
            await _loadService.GetAllLoads()
            );
        [HttpGet("{id}")]
        public async Task<ActionResult<LoadResponseDto>> GetLoad(int id) => HandleResultResponse(
            await _loadService.GetLoad(id)
            );
        [HttpPatch("{id}")]
        public async Task<ActionResult<LoadResponseDto>> UpdateLoad(int id, [FromBody] LoadUpdateDto dto) => HandleResultResponse(
            await _loadService.UpdateLoad(id, dto)
            );
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoadResponseDto>> DeleteLoad(int id) => HandleResultResponse(
            await _loadService.DeleteLoad(id)
            );
        [HttpPatch("{id}/accept")]
        public async Task<ActionResult<LoadResponseDto>> AcceptLoad(int id) => HandleResultResponse(
            await _loadService.AcceptLoad(id)
            );


    }
}
