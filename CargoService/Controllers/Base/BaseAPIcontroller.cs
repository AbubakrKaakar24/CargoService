using CargoService.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace CargoService.API.Controllers.Base
{
    public class BaseAPIcontroller:ControllerBase
    {
        public IActionResult HandleResult<T>(Result<T> response)
        {
            try
            {
                if (response.Success && response.Value == null)
                {
                    return NotFound();
                }
                else if (response.Success && response.Value != null)
                {
                    return Ok(response.Value);
                }
                else if (!response.Success && response.Errors != null)
                {
                    return BadRequest(response.Errors);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public ActionResult<T> HandleResultResponse<T>(Result<T> response)
        {
            try
            {
                if (response.Success && response.Value == null)
                {
                    return NotFound(response.Errors);
                }
    
                else if (response.Success && response.Value != null)
                {
                    return Ok(response.Value);
                }
                else if (!response.Success && response.Errors != null)
                {
                    return BadRequest(response.Errors);
                }

                else
                {
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
