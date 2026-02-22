using Calculator.API.Enums;
using Calculator.API.Services.CalculationStrategy;
using Calculator.TEST.Setup;

namespace Calculator.TEST.Test
{
    public class CalculatorServiceTestMultiplication : IClassFixture<CalculatorServiceFixture>
    {
        private readonly CalculatorServiceFixture _fixture;

        public CalculatorServiceTestMultiplication(CalculatorServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Execute_Multiplication_PositiveNumbers_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetMultiplicationPositiveNumbers();

            _fixture._mockFactory .Setup(f => f.Create(testData.Operation)).Returns(new MultiplyOperation());

            var response = _fixture._calculatorService.Execute(testData.Left, testData.Right,testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Multiplication_WithZero_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetMultiplicationWithZero();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)) .Returns(new MultiplyOperation());

            var response = _fixture._calculatorService.Execute(testData.Left,testData.Right,testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Multiplication_WithNegative_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetMultiplicationWithNegative();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new MultiplyOperation());

            var response = _fixture._calculatorService.Execute( testData.Left, testData.Right,testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Multiplication_BothNegative_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetMultiplicationBothNegative();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)) .Returns(new MultiplyOperation());

            var response = _fixture._calculatorService.Execute(testData.Left,testData.Right, testData.Operation );

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }
    }
}