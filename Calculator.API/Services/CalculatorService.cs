using Calculator.API.Enums;
using Calculator.API.Models;
using Calculator.API.Services.CalculationFactory;
using Calculator.API.Services.CalculationStrategy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.API.Services
{
    public class CalculatorService(ICalculationFactory _factory) : ICalculatorService
    {
        public CalculateResponse Execute(decimal firstNumber, decimal secondNumber, OperationType operatorSymbol)
        {
            try
            {
                var operation = _factory.Create(operatorSymbol);
                var result = operation.Calculate(firstNumber, secondNumber);
                return new CalculateResponse { Results = result, Error = CalculationError.None };
            }
            catch (DivideByZeroException)
            {
                return new CalculateResponse { Results = null, Error = CalculationError.DivisionByZero };
            }
            catch (NotSupportedException)
            {
                return new CalculateResponse { Results = null, Error = CalculationError.InvalidOperation };
            }
        }
    }
}

