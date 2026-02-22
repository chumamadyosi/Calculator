namespace Calculator.API.Services.CalculationStrategy
{
    public class MultiplyOperation : ICalculationOperation
    {
        public decimal Calculate(decimal left, decimal right)
        {
            return left * right;
        }
    }
}
