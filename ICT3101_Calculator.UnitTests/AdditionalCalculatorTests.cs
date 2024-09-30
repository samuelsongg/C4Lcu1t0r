using ICT3101_Calculator;
using Moq;
using NUnit.Framework;

[TestFixture]
public class AdditionalCalculatorTests
{
    private Calculator _calculator;
    private Mock<IFileReader> _mockFileReader;

    [SetUp]
    public void Setup()
    {
        // Initialize the mock for IFileReader
        _mockFileReader = new Mock<IFileReader>();
        _mockFileReader.Setup(fr => fr.Read("MagicNumbers.txt")).Returns(new string[] { "42", "42" });

        // Create a new instance of Calculator, passing in the mock IFileReader
        _calculator = new Calculator(_mockFileReader.Object);
    }

    [Test]
    public void GenMagicNum_ValidInput_ReturnsExpectedResult()
    {
        double input = 0; // Index 0 in the mock setup corresponds to value 42
        double result = _calculator.GenMagicNum(input, _mockFileReader.Object);

        Assert.AreEqual(84, result); // 42 * 2 = 84
    }

    [Test]
    public void GenMagicNum_NegativeInput_ReturnsNegativeDouble()
    {
        double input = -1; // Negative number to test fallback behavior
        double result = _calculator.GenMagicNum(input, _mockFileReader.Object);

        Assert.AreEqual(0, result); // Should return 0 for negative input.
    }

    [Test]
    public void GenMagicNum_InputOutOfBounds_ReturnsDefault()
    {
        double input = 100; // Index out of bounds
        double result = _calculator.GenMagicNum(input, _mockFileReader.Object);

        Assert.AreEqual(0, result); // Should return 0 as a fallback.
    }
}
