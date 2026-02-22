using Calculator.API.Enums;
using Calculator.API.Models;

namespace Calculator.API.Services
{
    public interface ICalculatorService
    {
        CalculateResponse Execute(decimal firstNumber, decimal secondNumber, OperationType operatorSymbol);
    }
}
