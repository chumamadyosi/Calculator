using Calculator.API.Enums;
using Calculator.API.Models;
using Calculator.API.Services;
using Calculator.API.Services.CalculationFactory;
using Calculator.API.Services.CalculationStrategy;
using Calculator.TEST.Setup;
using Moq;
using Xunit;

namespace Calculator.TEST.Test
{
    public class CalculatorServiceTestAddition : IClassFixture<CalculatorServiceFixture>
    {
        private readonly CalculatorServiceFixture _fixture;

        public CalculatorServiceTestAddition(CalculatorServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Execute_Addition_ReturnsCorrectResult()
        {
            // Arrange
            var request = CalculatorTestDataCollection.GetAdditionData();

            _fixture._mockFactory.Setup(f => f.Create(OperationType.Addition)).Returns(new AdditionOperation());

            // Act
            var response = _fixture._calculatorService.Execute(request.Left,request.Right,request.Operation);

            // Assert
            Assert.Equal(request.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }
    }
}