using ICT3101_Calculator;

public class CalculatorTests
{
    private Calculator _calculator;

    // Mock FileReader implementation for testing
    public class TestFileReader : IFileReader
    {
        public string[] Read(string path)
        {
            // Return a mock array of strings for testing purposes
            return new[] { "3", "4", "5", "7", "6", "8" };
        }
    }

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

    [Test]
    public void GenMagicNum_ValidInput_ReturnsExpectedResult()
    {
        // Arrange
        double input = 2; // Index in MagicNumbers.txt corresponds to value 5
        TestFileReader testReader = new TestFileReader();

        // Act
        double result = _calculator.GenMagicNum(input, testReader);

        // Assert
        Assert.AreEqual(10, result); // Because 3 * 2 = 6
    }

    [Test]
    public void GenMagicNum_NegativeInput_ReturnsNegativeDouble()
    {
        // Arrange
        double input = -1; // Negative number to test fallback behavior
        TestFileReader testReader = new TestFileReader();

        // Act
        double result = _calculator.GenMagicNum(input, testReader);

        // Assert
        Assert.AreEqual(0, result); // Should return 0 for negative input.
    }

    [Test]
    public void GenMagicNum_InputOutOfBounds_ReturnsDefault()
    {
        // Arrange
        double input = 100; // Index out of bounds
        TestFileReader testReader = new TestFileReader();

        // Act
        double result = _calculator.GenMagicNum(input, testReader);

        // Assert
        Assert.AreEqual(0, result); // Should return 0 as a fallback.
    }
}