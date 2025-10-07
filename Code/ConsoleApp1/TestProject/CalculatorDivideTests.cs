using Xunit;
using System.Reflection;

public class CalculatorDivideTests
{
    private double InvokeDivide(double num1, double num2)
    {
        var method = typeof(Calculator).GetMethod("Divide", BindingFlags.NonPublic | BindingFlags.Static);
        if (method == null)
            throw new MissingMethodException("O método não foi encontrado.");
        var result = method.Invoke(null, new object[] { num1, num2 });
        if (result == null)
            throw new InvalidOperationException("O método retornou nulo.");
        return (double)result;
    }

    // Divisão de dois números positivos
    [Fact]
    public void Divide_TwoPositiveNumbers_ReturnsPositiveResult()
    {
        double result = InvokeDivide(6, 3);
        Assert.Equal(2, result, 5);
    }

    // Divisão de número negativo por positivo
    [Fact]
    public void Divide_NegativeAndPositive_ReturnsNegativeResult()
    {
        double result = InvokeDivide(-6, 3);
        Assert.Equal(-2, result, 5);
    }

    // Divisão de número positivo por negativo
    [Fact]
    public void Divide_PositiveAndNegative_ReturnsNegativeResult()
    {
        double result = InvokeDivide(6, -3);
        Assert.Equal(-2, result, 5);
    }

    // Divisão de dois números negativos
    [Fact]
    public void Divide_TwoNegativeNumbers_ReturnsPositiveResult()
    {
        double result = InvokeDivide(-6, -3);
        Assert.Equal(2, result, 5);
    }

    // Divisão de zero por número positivo
    [Fact]
    public void Divide_ZeroAndPositive_ReturnsZero()
    {
        double result = InvokeDivide(0, 5);
        Assert.Equal(0, result, 5);
    }

    // Divisão de número positivo por número fracionário
    [Fact]
    public void Divide_PositiveByFractional_ReturnsExpected()
    {
        double result = InvokeDivide(4, 0.5);
        Assert.Equal(8, result, 5);
    }

    // Divisão que resulta em número decimal
    [Fact]
    public void Divide_IntegerResultInDecimal_ReturnsExpected()
    {
        double result = InvokeDivide(5, 2);
        Assert.Equal(2.5, result, 5);
    }

    // Divisão por zero deve lançar exceção
    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        var method = typeof(Calculator).GetMethod("Divide", BindingFlags.NonPublic | BindingFlags.Static);
        Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { 5, 0 }));
    }

    // Divisão de infinito por número positivo
    [Fact]
    public void Divide_InfinityByPositive_ReturnsInfinity()
    {
        double result = InvokeDivide(double.PositiveInfinity, 2);
        Assert.Equal(double.PositiveInfinity, result);
    }

    // Divisão de número positivo por infinito
    [Fact]
    public void Divide_PositiveByInfinity_ReturnsZero()
    {
        double result = InvokeDivide(5, double.PositiveInfinity);
        Assert.Equal(0, result, 5);
    }

    // Divisão de infinito por infinito retorna NaN
    [Fact]
    public void Divide_InfinityByInfinity_ReturnsNaN()
    {
        double result = InvokeDivide(double.PositiveInfinity, double.PositiveInfinity);
        Assert.True(double.IsNaN(result));
    }

    // Divisão de NaN por qualquer número retorna NaN
    [Fact]
    public void Divide_NaNByNumber_ReturnsNaN()
    {
        double result = InvokeDivide(double.NaN, 2);
        Assert.True(double.IsNaN(result));
    }

    // Divisão de número por NaN retorna NaN
    [Fact]
    public void Divide_NumberByNaN_ReturnsNaN()
    {
        double result = InvokeDivide(2, double.NaN);
        Assert.True(double.IsNaN(result));
    }

    // Divisão que causa underflow (número muito pequeno)
    [Fact]
    public void Divide_SmallNumbersUnderflow_ReturnsZero()
    {
        double result = InvokeDivide(double.Epsilon, 2);
        Assert.Equal(0, result, 5);
    }

    // Divisão com double.MaxValue e double.MinValue
    [Fact]
    public void Divide_MaxValueByMinValue_ReturnsNegativeResult()
    {
        double result = InvokeDivide(double.MaxValue, double.MinValue);
        Assert.True(result < 0);
    }
}
