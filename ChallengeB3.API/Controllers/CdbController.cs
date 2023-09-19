using ChallengeB3.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeB3.API.Controllers
{
    public class CdbController : ControllerBase
    {
        private readonly ICdbService _cdbService;

        public CdbController(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }

        [HttpGet("amount/{amount}/month/{month}")]
        public async Task<IActionResult> GetCdbCalculate(decimal amount, int month)
        {
            
            if (amount < 1 || month < 2)
                return BadRequest("Properties are invalids.");
            

            return Ok(await _cdbService.CalculateCDBReturn(amount, month));
        }
    }
}
