namespace Calculator.API.Services.CalculationStrategy
{
    public class AdditionOperation: ICalculationOperation
    {
        public decimal Calculate(decimal left, decimal right)
        {
            return left + right;
        }
    }
}
