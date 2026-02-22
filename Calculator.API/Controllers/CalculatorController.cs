using Calculator.API.Models;
using Calculator.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController(ICalculatorService calculatorService) : ControllerBase
    {
        private readonly ICalculatorService _calculatorService = calculatorService;

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculateRequest request)
        {
            var result = _calculatorService.Execute(request.Left, request.Right, request.Operation);
            if (result.Error != Enums.CalculationError.None)
            {
                return BadRequest(new { error = result.Error.ToString() });
            }
            return Ok(new { result = result.Results });
        }
    }
}
