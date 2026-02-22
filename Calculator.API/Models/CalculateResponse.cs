using Calculator.API.Enums;

namespace Calculator.API.Models
{
    public class CalculateResponse
    {
        public decimal Results { get; set; }
        public CalculationError Error { get; set; } = CalculationError.None;
    }
}
