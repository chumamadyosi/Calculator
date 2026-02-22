namespace Calculator.API.Services.CalculationStrategy
{
    public class SubtractionOperation : ICalculationOperation
    {
        public decimal Calculate(decimal left, decimal right)
        {
            return left - right;
        }
    }
}
