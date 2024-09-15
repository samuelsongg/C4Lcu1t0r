public class CalculatorTests
{
    private Calculator _calculator;
    [SetUp]
    public void Setup()
    {
        // Arrange
        _calculator = new Calculator();
    }
    [Test]
    public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
    {
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }
    [Test]
    public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToSubtraction()
    {
        double result = _calculator.Subtract(20, 10);
        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToMultiplication()
    {
        double result = _calculator.Multiply(20, 10);
        Assert.That(result, Is.EqualTo(200));
    }
    [Test]
    public void Divide_WhenDividingTwoNumbers_ResultEqualtoDivision()
    {
        double result = _calculator.Divide(200, 10);
        Assert.That(result, Is.EqualTo(20));
    }
    [Test]
    [TestCase(0, 0)]
    [TestCase(0, 10)]
    [TestCase(10, 0)]
    public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
    }

    [Test]
    [TestCase(0)]
    [TestCase(-10)]
    public void Factorial_CalculateFactorial_ResultThrowArgumentException(double a)
    {
        Assert.That(() => _calculator.Factorial(a), Throws.ArgumentException);
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(0, -2)]
    [TestCase(-10, 0)]
    [TestCase(-10, -10)]
    public void Area_AreaOfTriangle_ResultThrowArgumentException(double length, double height)
    {
        Assert.That(() => _calculator.Triangle(length, height), Throws.ArgumentException);
    }

    [Test]
    [TestCase(0)]
    [TestCase(-10)]
    public void Area_AreaOfCircle_ResultThrowArgumentException(double radius)
    {
        Assert.That(() => _calculator.Circle(radius), Throws.ArgumentException);
    }
}