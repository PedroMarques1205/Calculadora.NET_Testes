using System.Reflection;
using Xunit;

public class CalculatorIntegrationTests
{
    private double InvokePrivate(string methodName, params object[] parameters)
    {
        var method = typeof(Calculator).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
        if (method == null)
            throw new MissingMethodException($"Método '{methodName}' não encontrado.");
        var result = method.Invoke(null, parameters);
        if (result == null)
            throw new InvalidOperationException($"O método '{methodName}' retornou nulo.");
        return (double)result;
    }

    private double InvokeAdd(double num1, double num2) => InvokePrivate("Add", num1, num2);
    private double InvokeSubtract(double num1, double num2) => InvokePrivate("Subtract", num1, num2);
    private double InvokeMultiply(double num1, double num2) => InvokePrivate("Multiply", num1, num2);
    private double InvokeDivide(double num1, double num2) => InvokePrivate("Divide", num1, num2);

    [Fact]
    public void Integration_MultipleOperations_ReturnsExpectedResult()
    {
        double addResult = InvokeAdd(2, 3);                 
        double multiplyResult = InvokeMultiply(addResult, 4);
        double divideResult = InvokeDivide(multiplyResult, 2);
        double finalResult = InvokeSubtract(divideResult, 1);

        Assert.Equal(9, finalResult, 5);
    }

    [Fact]
    public void Integration_WithEdgeCases_ReturnsExpected()
    {
        double addResult = InvokeAdd(-10, 5);
        double divideResult = InvokeDivide(addResult, -5);
        double multiplyResult = InvokeMultiply(divideResult, 2);

        Assert.Equal(2, multiplyResult, 5);
    }
}
