public class CalculatorContext
{
    public Calculator Calculator { get; set; }

    public CalculatorContext()
    {
        Calculator = new Calculator(); // Initialize the calculator
    }
}
