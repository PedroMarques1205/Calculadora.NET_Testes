using Xunit;
using System.Reflection;

public class CalculatorTests
{
    private double InvokeMultiply(double num1, double num2)
    {
        var method = typeof(Calculator).GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Static);
        return (double)method.Invoke(null, new object[] { num1, num2 });
    }

    [Fact]
    public void Multiply_TwoPositiveNumbers_ReturnsPositiveResult()
    {
        double result = InvokeMultiply(2, 3);
        Assert.Equal(6, result, 5);
    }

    [Fact]
    public void Multiply_NegativeAndPositive_ReturnsNegativeResult()
    {
        double result = InvokeMultiply(-2, 3);
        Assert.Equal(-6, result, 5);
    }

    [Fact]
    public void Multiply_PositiveAndNegative_ReturnsNegativeResult()
    {
        double result = InvokeMultiply(2, -3);
        Assert.Equal(-6, result, 5);
    }

    [Fact]
    public void Multiply_TwoNegativeNumbers_ReturnsPositiveResult()
    {
        double result = InvokeMultiply(-2, -3);
        Assert.Equal(6, result, 5);
    }

    [Fact]
    public void Multiply_ZeroAndPositive_ReturnsZero()
    {
        double result = InvokeMultiply(0, 5);
        Assert.Equal(0, result, 5);
    }

    [Fact]
    public void Multiply_PositiveAndZero_ReturnsZero()
    {
        double result = InvokeMultiply(5, 0);
        Assert.Equal(0, result, 5);
    }

    [Fact]
    public void Multiply_DecimalAndInteger_ReturnsExpected()
    {
        double result = InvokeMultiply(1.5, 2);
        Assert.Equal(3.0, result, 5);
    }

    [Fact]
    public void Multiply_FractionalNumbers_ReturnsExpected()
    {
        double result = InvokeMultiply(2.5, 4);
        Assert.Equal(10.0, result, 5);
    }

    [Fact]
    public void Multiply_LargeNumbers_ReturnsExpected()
    {
        double result = InvokeMultiply(1e6, 1e6);
        Assert.Equal(1e12, result, 5);
    }

    [Fact]
    public void Multiply_MaxValueEdgeCase_ReturnsExpected()
    {
        double result = InvokeMultiply(double.MaxValue / 2, 2);
        Assert.Equal(double.MaxValue, result, 5);
    }
}