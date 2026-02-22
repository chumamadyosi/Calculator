using Calculator.API.Models;
using FluentValidation;

namespace Calculator.API.Validation
{
    public class CalculateRequestValidator : AbstractValidator<CalculateRequest>
    {
        public CalculateRequestValidator()
        {
            RuleFor(x => x.Left).NotNull().WithMessage("Left value is required.");
            RuleFor(x => x.Right).NotNull().WithMessage("Right value is required.");
            RuleFor(x => x.Operation).IsInEnum().WithMessage("Invalid operation type.");
        }
    }
}
