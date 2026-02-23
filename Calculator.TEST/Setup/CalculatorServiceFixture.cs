using Calculator.API.Services;
using Calculator.API.Services.CalculationFactory;
using Microsoft.Extensions.Logging;
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
        public ILogger<CalculatorService> _logger;
        public ICalculatorService _calculatorService { get; }

        public CalculatorServiceFixture()
        {
            _mockFactory = new Mock<ICalculationFactory>();
            _calculatorService = new CalculatorService(_mockFactory.Object, _logger);
        }
    }
}
