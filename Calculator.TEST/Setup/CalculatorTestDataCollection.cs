using Calculator.API.Enums;
using Calculator.API.Models;

namespace Calculator.TEST.Setup
{
    public static class CalculatorTestDataCollection
    {
        public record TestCalculateData(decimal Left, decimal Right, OperationType Operation, decimal ExpectedResult);


        public static TestCalculateData GetAdditionData()
        {
            return new TestCalculateData(Left: 10, Right: 5, Operation: OperationType.Addition, ExpectedResult: 15);
        }
        public static TestCalculateData GetAdditionWithNegative() => new TestCalculateData(-3, 7, OperationType.Addition, 4);
        public static TestCalculateData GetAdditionWithZero() => new TestCalculateData(0, 5, OperationType.Addition, 5);
        public static TestCalculateData GetAdditionBothNegative() => new TestCalculateData(-4, -6, OperationType.Addition, -10);

        public static TestCalculateData GetSubtractionData()
        {
            return new TestCalculateData(Left: 10, Right: 5, Operation: OperationType.Subtraction, ExpectedResult: 5);
        }
        public static TestCalculateData GetSubtractionWithZero() => new TestCalculateData(10, 0, OperationType.Subtraction, 10);

        public static TestCalculateData GetSubtractionWithNegative() => new TestCalculateData(10, -5, OperationType.Subtraction, 15);

        public static TestCalculateData GetSubtractionBothNegative() => new TestCalculateData(-10, -5, OperationType.Subtraction, -5);


        public static TestCalculateData GetMultiplicationPositiveNumbers() => new TestCalculateData(10, 5, OperationType.Multiplication, 50);
        public static TestCalculateData GetMultiplicationWithZero() => new TestCalculateData(10, 0, OperationType.Multiplication, 0);
        public static TestCalculateData GetMultiplicationWithNegative() => new TestCalculateData(-3, 7, OperationType.Multiplication, -21);
        public static TestCalculateData GetMultiplicationBothNegative() => new TestCalculateData(-4, -6, OperationType.Multiplication, 24);

        public static TestCalculateData GetDivisionPositiveNumbers() => new TestCalculateData(10, 5, OperationType.Division, 2);
        public static TestCalculateData GetDivisionWithNegative() => new TestCalculateData(-10, 5, OperationType.Division, -2);
        public static TestCalculateData GetDivisionBothNegative() => new TestCalculateData(-10, -5, OperationType.Division, 2);
        public static TestCalculateData GetDivisionZeroNumerator() => new TestCalculateData(0, 5, OperationType.Division, 0);
        public static TestCalculateData GetDivisionByZero() => new TestCalculateData(10, 0, OperationType.Division, 0);
    }
}
