using Calculator.API.Enums;
using Calculator.API.Services.CalculationStrategy;

namespace Calculator.API.Services.CalculationFactory
{
    public interface ICalculationFactory
    {
        ICalculationOperation Create(OperationType operationType);
    }
}
