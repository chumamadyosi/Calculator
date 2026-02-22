namespace Calculator.API.Services.CalculationStrategy
{
    public class DivideOperation : ICalculationOperation
    {
        public decimal Calculate(decimal left, decimal right)
        {
            if (right == 0)

                throw new DivideByZeroException("Cannot divide by zero.");
            return left / right;
        }
    }
}
