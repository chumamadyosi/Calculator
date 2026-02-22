using Calculator.API.Services;
using Calculator.API.Services.CalculationFactory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TEST.Setup
{
    public class CalculatorServiceFixture
    {
        public Mock<ICalculationFactory> _mockFactory { get; }
        public ICalculatorService _calculatorService { get; }

        public CalculatorServiceFixture()
        {
            _mockFactory = new Mock<ICalculationFactory>();
            _calculatorService = new CalculatorService(_mockFactory.Object);
        }
    }
}
