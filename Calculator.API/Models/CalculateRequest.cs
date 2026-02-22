using Calculator.API.Enums;

namespace Calculator.API.Models
{
    public record CalculateRequest(decimal Left, decimal Right, OperationType Operation);

}
