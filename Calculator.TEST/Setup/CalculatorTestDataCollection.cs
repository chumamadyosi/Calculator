using Calculator.API.Enums;
using Calculator.API.Models;

namespace Calculator.TEST.Setup
{
    public static class CalculatorTestDataCollection
    {
        public record TestCalculateData(decimal Left, decimal Right, OperationType Operation, decimal ExpectedResult);


        public static TestCalculateData GetAdditionData()
        {
            return new TestCalculateData(
                Left: 10,
                Right: 5,
                Operation: OperationType.Addition,
                ExpectedResult: 15
            );
        }
        public static TestCalculateData GetSubtractionData()
        {
            return new TestCalculateData(
                Left: 10,
                Right: 5,
                Operation: OperationType.Subtraction,
                ExpectedResult: 5
            );
        }

        public static TestCalculateData GetMultiplicationData()
        {
            return new TestCalculateData(
                Left: 10,
                Right: 5,
                Operation: OperationType.Multiplication,
                ExpectedResult: 50
            );
        }

        public static TestCalculateData GetDivisionData()
        {
            return new TestCalculateData(
                Left: 10,
                Right: 5,
                Operation: OperationType.Division,
                ExpectedResult: 2
            );
        }
    }
}
