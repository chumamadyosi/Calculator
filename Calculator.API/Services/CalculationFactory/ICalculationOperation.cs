using Calculator.API.Enums;

namespace Calculator.API.Services.CalculationStrategy
{
    public interface ICalculationOperation
    {
        decimal Calculate(decimal left, decimal right);
    }
}
