using Calculator.API.Enums;
using Calculator.API.Services.CalculationStrategy;

namespace Calculator.API.Services.CalculationFactory
{
    public class CalculatorFactory : ICalculationFactory
    {
        public  ICalculationOperation Create(OperationType operationType)
        {
            return operationType switch
            {
                OperationType.Addition=> new AdditionOperation(),
                OperationType.Subtraction => new SubtractionOperation(),
                OperationType.Multiplication => new MultiplyOperation(),
                OperationType.Division => new DivideOperation(),
                _ => throw new NotSupportedException($"Operation type '{operationType}' is not supported.")
            };
        }
    }
}
