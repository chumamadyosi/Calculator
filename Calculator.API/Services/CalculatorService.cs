using Calculator.API.Enums;
using Calculator.API.Models;
using Calculator.API.Services.CalculationFactory;
using Calculator.API.Services.CalculationStrategy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.API.Services
{
    public class CalculatorService(ICalculationFactory _factory, ILogger<CalculatorService> _logger) : ICalculatorService
    {
        public CalculateResponse Execute(decimal firstNumber, decimal secondNumber, OperationType operatorSymbol)
        {
            try
            {
                var operation = _factory.Create(operatorSymbol);
                var result = operation.Calculate(firstNumber, secondNumber);
                return new CalculateResponse { Results = result, Error = CalculationError.None };
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogWarning(ex, "User attempted division by zero: {firstNumber} / 0", firstNumber);
                return new CalculateResponse { Results = null, Error = CalculationError.DivisionByZero };
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, "Operation type {operatorSymbol} is not supported. ", operatorSymbol);
                return new CalculateResponse { Results = null, Error = CalculationError.InvalidOperation };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Unexpected error in CalculatorService during {operatorSymbol} operation", operatorSymbol);
                return new CalculateResponse { Results = null, Error = CalculationError.unknownError };
            }
        }

    }
}

