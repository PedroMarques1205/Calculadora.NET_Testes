using Xunit;
using System.Reflection;

public class CalculatorSubtractTests
{
    // Método auxiliar para chamar o Subtract, já que ele é private
    private double InvokeSubtract(double num1, double num2)
    {
        var method = typeof(Calculator).GetMethod("Subtract", BindingFlags.NonPublic | BindingFlags.Static);
        return (double)method.Invoke(null, new object[] { num1, num2 });
    }

    // Subtração de dois números positivos
    [Fact]
    public void Subtract_TwoPositiveNumbers_ReturnsPositiveResult()
    {
        double result = InvokeSubtract(5, 3);
        Assert.Equal(2, result, 5);
    }

    // Subtração de número negativo por positivo
    [Fact]
    public void Subtract_NegativeAndPositive_ReturnsNegativeResult()
    {
        double result = InvokeSubtract(-5, 3);
        Assert.Equal(-8, result, 5);
    }

    // Subtração de número positivo por negativo
    [Fact]
    public void Subtract_PositiveAndNegative_ReturnsPositiveResult()
    {
        double result = InvokeSubtract(5, -3);
        Assert.Equal(8, result, 5);
    }

    // Subtração de dois números negativos
    [Fact]
    public void Subtract_TwoNegativeNumbers_ReturnsExpectedResult()
    {
        double result = InvokeSubtract(-5, -3);
        Assert.Equal(-2, result, 5);
    }

    // Subtração de zero por número positivo
    [Fact]
    public void Subtract_ZeroAndPositive_ReturnsNegativeResult()
    {
        double result = InvokeSubtract(0, 5);
        Assert.Equal(-5, result, 5);
    }

    // Subtração de número positivo por zero
    [Fact]
    public void Subtract_PositiveAndZero_ReturnsSameNumber()
    {
        double result = InvokeSubtract(5, 0);
        Assert.Equal(5, result, 5);
    }

    // Subtração de decimal por inteiro
    [Fact]
    public void Subtract_DecimalAndInteger_ReturnsExpected()
    {
        double result = InvokeSubtract(5.5, 2);
        Assert.Equal(3.5, result, 5);
    }

    // Subtração de número fracionário por inteiro
    [Fact]
    public void Subtract_FractionalNumbers_ReturnsExpected()
    {
        double result = InvokeSubtract(4.2, 1.2);
        Assert.Equal(3.0, result, 5);
    }

    // Subtração de números grandes
    [Fact]
    public void Subtract_LargeNumbers_ReturnsExpected()
    {
        double result = InvokeSubtract(1e12, 1e6);
        Assert.Equal(999999000000, result, 5);
    }

    // Subtração usando double.MaxValue
    [Fact]
    public void Subtract_MaxValueEdgeCase_ReturnsExpected()
    {
        double result = InvokeSubtract(double.MaxValue, 1);
        Assert.Equal(double.MaxValue - 1, result, 5);
    }

    // Subtração envolvendo double.MinValue
    [Fact]
    public void Subtract_MinValueEdgeCase_ReturnsExpected()
    {
        double result = InvokeSubtract(double.MinValue, -1);
        Assert.Equal(double.MinValue + 1, result, 5);
    }

    // Subtração envolvendo NaN
    [Fact]
    public void Subtract_NaN_ReturnsNaN()
    {
        double result = InvokeSubtract(double.NaN, 1);
        Assert.True(double.IsNaN(result));
    }

    // Subtração infinito - infinito retorna NaN
    [Fact]
    public void Subtract_InfinityMinusInfinity_ReturnsNaN()
    {
        double result = InvokeSubtract(double.PositiveInfinity, double.PositiveInfinity);
        Assert.True(double.IsNaN(result));
    }

    // Subtração de números muito pequenos (underflow) retorna próximo de zero
    [Fact]
    public void Subtract_SmallNumbersUnderflow_ReturnsExpected()
    {
        double result = InvokeSubtract(double.Epsilon, double.Epsilon);
        Assert.Equal(0, result, 5);
    }
}
