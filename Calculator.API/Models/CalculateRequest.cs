namespace Calculator.API.Models
{
    public record CalculateRequest(decimal FirstNumber, decimal SecondNumber, string Operator);

}
