using Xunit;
using System.Reflection;

public class CalculatorTests
{
    private double InvokeMultiply(double num1, double num2)
    {
        var method = typeof(Calculator).GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Static);
        if (method == null)
            throw new MissingMethodException("Método não encontrado.");
        var result = method.Invoke(null, new object[] { num1, num2 });
        if (result == null)
            throw new InvalidOperationException("O método retornou nulo.");
        return (double)result;
    }

    // Multiplicação de dois números positivos
    [Fact]
    public void Multiply_TwoPositiveNumbers_ReturnsPositiveResult()
    {
        double result = InvokeMultiply(2, 3);
        Assert.Equal(6, result, 5);
    }

    // Multiplicação de número negativo por positivo
    [Fact]
    public void Multiply_NegativeAndPositive_ReturnsNegativeResult()
    {
        double result = InvokeMultiply(-2, 3);
        Assert.Equal(-6, result, 5);
    }

    // Multiplicação de número positivo por negativo
    [Fact]
    public void Multiply_PositiveAndNegative_ReturnsNegativeResult()
    {
        double result = InvokeMultiply(2, -3);
        Assert.Equal(-6, result, 5);
    }

    // Multiplicação de dois números negativos
    [Fact]
    public void Multiply_TwoNegativeNumbers_ReturnsPositiveResult()
    {
        double result = InvokeMultiply(-2, -3);
        Assert.Equal(6, result, 5);
    }

    // Multiplicação de zero por número positivo
    [Fact]
    public void Multiply_ZeroAndPositive_ReturnsZero()
    {
        double result = InvokeMultiply(0, 5);
        Assert.Equal(0, result, 5);
    }

    // Multiplicação de número positivo por zero
    [Fact]
    public void Multiply_PositiveAndZero_ReturnsZero()
    {
        double result = InvokeMultiply(5, 0);
        Assert.Equal(0, result, 5);
    }

    // Multiplicação de decimal por inteiro
    [Fact]
    public void Multiply_DecimalAndInteger_ReturnsExpected()
    {
        double result = InvokeMultiply(1.5, 2);
        Assert.Equal(3.0, result, 5);
    }

    // Multiplicação de número fracionário por inteiro
    [Fact]
    public void Multiply_FractionalNumbers_ReturnsExpected()
    {
        double result = InvokeMultiply(2.5, 4);
        Assert.Equal(10.0, result, 5);
    }

    // Multiplicação de números grandes
    [Fact]
    public void Multiply_LargeNumbers_ReturnsExpected()
    {
        double result = InvokeMultiply(1e6, 1e6);
        Assert.Equal(1e12, result, 5);
    }

    // Caso de borda usando double.MaxValue
    [Fact]
    public void Multiply_MaxValueEdgeCase_ReturnsExpected()
    {
        double result = InvokeMultiply(double.MaxValue / 2, 2);
        Assert.Equal(double.MaxValue, result, 5);
    }

    // Overflow positivo: resultado maior que double.MaxValue
    [Fact]
    public void Multiply_PositiveOverflow_ReturnsInfinity()
    {
        double result = InvokeMultiply(double.MaxValue, 2);
        Assert.Equal(double.PositiveInfinity, result);
    }

    // Overflow negativo: resultado menor que double.MinValue
    [Fact]
    public void Multiply_NegativeOverflow_ReturnsNegativeInfinity()
    {
        double result = InvokeMultiply(double.MinValue, 2);
        Assert.Equal(double.NegativeInfinity, result);
    }

    // Multiplicação envolvendo NaN (Not a Number)
    [Fact]
    public void Multiply_NaN_ReturnsNaN()
    {
        double result = InvokeMultiply(double.NaN, 1);
        Assert.True(double.IsNaN(result));
    }

    // Multiplicação infinito × zero retorna NaN
    [Fact]
    public void Multiply_InfinityTimesZero_ReturnsNaN()
    {
        double result = InvokeMultiply(double.PositiveInfinity, 0);
        Assert.True(double.IsNaN(result));
    }

    // Multiplicação de números muito pequenos (underflow) retorna 0
    [Fact]
    public void Multiply_SmallNumbersUnderflow_ReturnsZero()
    {
        double result = InvokeMultiply(double.Epsilon, 0.5);
        Assert.Equal(0, result);
    }
}
