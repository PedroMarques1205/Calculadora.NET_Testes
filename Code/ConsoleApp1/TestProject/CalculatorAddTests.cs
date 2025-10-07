using System.Reflection;

public class CalculatorAddTests
{
    private double InvokeAdd(double num1, double num2)
    {
        var method = typeof(Calculator).GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Static);
        return (double)method.Invoke(null, new object[] { num1, num2 });
    }

    // Adição de dois números positivos
    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsPositiveResult()
    {
        double result = InvokeAdd(2, 3);
        Assert.Equal(5, result, 5);
    }

    // Adição de número negativo com positivo
    [Fact]
    public void Add_NegativeAndPositive_ReturnsExpected()
    {
        double result = InvokeAdd(-2, 5);
        Assert.Equal(3, result, 5);
    }

    // Adição de número positivo com negativo
    [Fact]
    public void Add_PositiveAndNegative_ReturnsExpected()
    {
        double result = InvokeAdd(5, -2);
        Assert.Equal(3, result, 5);
    }

    // Adição de dois números negativos
    [Fact]
    public void Add_TwoNegativeNumbers_ReturnsNegativeResult()
    {
        double result = InvokeAdd(-2, -3);
        Assert.Equal(-5, result, 5);
    }

    // Adição de zero com número positivo
    [Fact]
    public void Add_ZeroAndPositive_ReturnsPositive()
    {
        double result = InvokeAdd(0, 5);
        Assert.Equal(5, result, 5);
    }

    // Adição de número positivo com zero
    [Fact]
    public void Add_PositiveAndZero_ReturnsPositive()
    {
        double result = InvokeAdd(5, 0);
        Assert.Equal(5, result, 5);
    }

    // Adição de zero com zero
    [Fact]
    public void Add_ZeroAndZero_ReturnsZero()
    {
        double result = InvokeAdd(0, 0);
        Assert.Equal(0, result, 5);
    }

    // Adição de decimal com inteiro
    [Fact]
    public void Add_DecimalAndInteger_ReturnsExpected()
    {
        double result = InvokeAdd(1.5, 2);
        Assert.Equal(3.5, result, 5);
    }

    // Adição de números fracionários
    [Fact]
    public void Add_FractionalNumbers_ReturnsExpected()
    {
        double result = InvokeAdd(2.5, 4.7);
        Assert.Equal(7.2, result, 5);
    }

    // Adição de números grandes
    [Fact]
    public void Add_LargeNumbers_ReturnsExpected()
    {
        double result = InvokeAdd(1e15, 1e15);
        Assert.Equal(2e15, result, 5);
    }

    // Caso de borda usando double.MaxValue
    [Fact]
    public void Add_MaxValueEdgeCase_ReturnsExpected()
    {
        double result = InvokeAdd(double.MaxValue / 2, double.MaxValue / 2);
        Assert.Equal(double.MaxValue, result, 5);
    }

    // Overflow positivo: resultado maior que double.MaxValue
    [Fact]
    public void Add_PositiveOverflow_ReturnsInfinity()
    {
        double result = InvokeAdd(double.MaxValue, double.MaxValue);
        Assert.Equal(double.PositiveInfinity, result);
    }

    // Overflow negativo: resultado menor que double.MinValue
    [Fact]
    public void Add_NegativeOverflow_ReturnsNegativeInfinity()
    {
        double result = InvokeAdd(double.MinValue, double.MinValue);
        Assert.Equal(double.NegativeInfinity, result);
    }

    // Adição envolvendo NaN (Not a Number)
    [Fact]
    public void Add_NaN_ReturnsNaN()
    {
        double result = InvokeAdd(double.NaN, 1);
        Assert.True(double.IsNaN(result));
    }

    // Adição de infinito positivo com número finito
    [Fact]
    public void Add_PositiveInfinityWithFinite_ReturnsInfinity()
    {
        double result = InvokeAdd(double.PositiveInfinity, 100);
        Assert.Equal(double.PositiveInfinity, result);
    }

    // Adição de infinito negativo com número finito
    [Fact]
    public void Add_NegativeInfinityWithFinite_ReturnsNegativeInfinity()
    {
        double result = InvokeAdd(double.NegativeInfinity, 100);
        Assert.Equal(double.NegativeInfinity, result);
    }

    // Adição de infinito positivo com infinito negativo retorna NaN
    [Fact]
    public void Add_PositiveInfinityWithNegativeInfinity_ReturnsNaN()
    {
        double result = InvokeAdd(double.PositiveInfinity, double.NegativeInfinity);
        Assert.True(double.IsNaN(result));
    }

    // Adição de números muito pequenos (underflow mantém precisão)
    [Fact]
    public void Add_VerySmallNumbers_ReturnsExpected()
    {
        double result = InvokeAdd(double.Epsilon, double.Epsilon);
        Assert.Equal(double.Epsilon * 2, result);
    }

    // Propriedade comutativa: a + b = b + a
    [Fact]
    public void Add_CommutativeProperty_ReturnsEqual()
    {
        double result1 = InvokeAdd(3.7, 2.1);
        double result2 = InvokeAdd(2.1, 3.7);
        Assert.Equal(result1, result2, 5);
    }

    // Propriedade associativa com número negativo que resulta em zero
    [Fact]
    public void Add_OppositeNumbers_ReturnsZero()
    {
        double result = InvokeAdd(5.5, -5.5);
        Assert.Equal(0, result, 5);
    }
}