class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Calculator _calculator = new Calculator();
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            try
            {
                // Declare variables and set to empty.
                double cleanNum1 = 0, cleanNum2 = 0, cleanNum3 = 0, cleanNum4 = 0;
                double result = 0;

                // Ask the user to choose an operator first.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tf - Factorial");
                Console.WriteLine("\tt - Area of Triangle");
                Console.WriteLine("\tc - Area of Circle");
                Console.WriteLine("\t1 - Qn17 a)");
                Console.WriteLine("\t2 - Qn17 b)");
                Console.WriteLine("\tmtbf - Calculate MTBF");
                Console.WriteLine("\tavailability - Calculate Availability");
                Console.WriteLine("\tfailureintensity - Calculate Failure Intensity");
                Console.WriteLine("\texpectedfailures - Calculate Expected Failures");
                Console.WriteLine("\tdefectdensity - Calculate Defect Density");
                Console.WriteLine("\tmusalog - Calculate Musa Log Reliability");
                Console.Write("Your option? ");
                string op = Console.ReadLine();

                // Based on the operation, ask for the necessary number of inputs
                switch (op)
                {
                    case "a":
                    case "s":
                    case "m":
                    case "d":
                    case "mtbf":
                    case "availability":
                        // Two numbers required
                        cleanNum1 = GetNumberFromUser("first");
                        cleanNum2 = GetNumberFromUser("second");
                        result = (double)_calculator.DoOperation(cleanNum1, cleanNum2, 0, 0, op);
                        break;

                    case "t":
                        // Two numbers for Triangle
                        cleanNum1 = GetNumberFromUser("base length");
                        cleanNum2 = GetNumberFromUser("height");
                        result = (double)_calculator.DoOperation(cleanNum1, cleanNum2, 0, 0, op);
                        break;

                    case "c":
                        // One number for Circle
                        cleanNum1 = GetNumberFromUser("radius");
                        result = (double)_calculator.DoOperation(cleanNum1, 0, 0, 0, op);
                        break;

                    case "f":
                        // One number for Factorial
                        cleanNum1 = GetNumberFromUser("number");
                        result = (double)_calculator.DoOperation(cleanNum1, 0, 0, 0, op);
                        break;

                    case "failureintensity":
                    case "expectedfailures":
                        // Three numbers required
                        cleanNum1 = GetNumberFromUser("initial failure intensity");
                        cleanNum2 = GetNumberFromUser("average failures");
                        cleanNum3 = GetNumberFromUser("total failures");
                        result = (double)_calculator.DoOperation(cleanNum1, cleanNum2, cleanNum3, 0, op);
                        break;

                    case "defectdensity":
                        // Two numbers for defect density
                        cleanNum1 = GetNumberFromUser("number of defects");
                        cleanNum2 = GetNumberFromUser("SSI");
                        result = (double)_calculator.DoOperation(cleanNum1, cleanNum2, 0, 0, op);
                        break;

                    case "musalog":
                        // Four numbers required
                        cleanNum1 = GetNumberFromUser("lambda0");
                        cleanNum2 = GetNumberFromUser("theta");
                        cleanNum3 = GetNumberFromUser("mu");
                        cleanNum4 = GetNumberFromUser("time");
                        var reliabilityResult = _calculator.DoOperation(cleanNum1, cleanNum2, cleanNum3, cleanNum4, op);
                        Console.WriteLine($"Your result: {reliabilityResult}\n");
                        break;

                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }

                if (!double.IsNaN(result))
                {
                    Console.WriteLine("Your result: {0:0.##}\n", result);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An unexpected exception occurred trying math.\n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");
            Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "q") endApp = true;
            Console.WriteLine("\n");
        }
    }

    private static double GetNumberFromUser(string prompt)
    {
        string input;
        double number;
        Console.Write($"Type the {prompt} number, and then press Enter: ");
        input = Console.ReadLine();
        while (!double.TryParse(input, out number))
        {
            Console.Write($"This is not valid input. Please enter a valid number for {prompt}: ");
            input = Console.ReadLine();
        }
        return number;
    }
}
