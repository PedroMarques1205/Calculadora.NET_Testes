using Xunit;

public class CalculatorIntegrationTests
{
    [Fact]
    public void Integration_MultipleOperations_ReturnsExpectedResult()
    {
        // Cenário: (2 + 3) * 4 / 2 - 1 = 9
        double addResult = Calculator.Add(2, 3);          // 2 + 3 = 5
        double multiplyResult = Calculator.Multiply(addResult, 4); // 5 * 4 = 20
        double divideResult = Calculator.Divide(multiplyResult, 2); // 20 / 2 = 10
        double finalResult = Calculator.Subtract(divideResult, 1);  // 10 - 1 = 9

        Assert.Equal(9, finalResult, 5); 
    }

    // Teste de integração incluindo casos extremos
    [Fact]
    public void Integration_WithEdgeCases_ReturnsExpected()
    {
        // Cenário: (-10 + 5) / (-5) * 2 = 2
        double addResult = Calculator.Add(-10, 5);       // -10 + 5 = -5
        double divideResult = Calculator.Divide(addResult, -5); // -5 / -5 = 1
        double multiplyResult = Calculator.Multiply(divideResult, 2); // 1 * 2 = 2

        Assert.Equal(2, multiplyResult, 5);
    }
}
