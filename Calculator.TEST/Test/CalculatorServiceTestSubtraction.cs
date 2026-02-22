using Calculator.API.Enums;
using Calculator.API.Services.CalculationStrategy;
using Calculator.TEST.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TEST.Test
{
    public class CalculatorServiceTestSubtraction : IClassFixture<CalculatorServiceFixture>
    {
        private readonly CalculatorServiceFixture _fixture;
        public CalculatorServiceTestSubtraction(CalculatorServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Execute_Subtraction_PositiveNumbers_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetSubtractionData();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new SubtractionOperation());

            var response = _fixture._calculatorService.Execute(testData.Left, testData.Right, testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }
        [Fact]
        public void Execute_Subtraction_WithZero_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetSubtractionWithZero();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new SubtractionOperation());

            var response = _fixture._calculatorService.Execute(testData.Left, testData.Right, testData.Operation
            );

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Subtraction_WithNegative_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetSubtractionWithNegative();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new SubtractionOperation());

            var response = _fixture._calculatorService.Execute(testData.Left, testData.Right, testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }

        [Fact]
        public void Execute_Subtraction_BothNegative_ReturnsCorrectResult()
        {
            var testData = CalculatorTestDataCollection.GetSubtractionBothNegative();

            _fixture._mockFactory.Setup(f => f.Create(testData.Operation)).Returns(new SubtractionOperation());

            var response = _fixture._calculatorService.Execute(testData.Left, testData.Right, testData.Operation);

            Assert.Equal(testData.ExpectedResult, response.Results);
            Assert.Equal(CalculationError.None, response.Error);
        }
    }
}

