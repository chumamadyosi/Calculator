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
    public class CalculatorServiceTestDivision : IClassFixture<CalculatorServiceFixture>
    {
        private readonly CalculatorServiceFixture _fixture;

        public CalculatorServiceTestDivision(CalculatorServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Execute_Division_PositiveNumbers_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetDivisionPositiveNumbers();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new DivideOperation());

            var response = _fixture._calculatorService.Execute(testData.Left,testData.Right,testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Division_WithNegative_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetDivisionWithNegative();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new DivideOperation());

            var response = _fixture._calculatorService.Execute( testData.Left, testData.Right,testData.Operation );

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Division_BothNegative_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetDivisionBothNegative();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new DivideOperation());

            var response = _fixture._calculatorService.Execute(testData.Left,testData.Right, testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Division_ZeroNumerator_ReturnsZero()
        {
            var testData = CalculatorTestDataCollection.GetDivisionZeroNumerator();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new DivideOperation());

            var response = _fixture._calculatorService.Execute(testData.Left, testData.Right,testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results); 
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Division_ByZero_ReturnsError()
        {
            var testData = CalculatorTestDataCollection.GetDivisionByZero();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new DivideOperation());

            var response = _fixture._calculatorService.Execute(testData.Left,testData.Right,testData.Operation);

            Assert.Equal(CalculationError.DivisionByZero, response.Error);
        }
    }
}