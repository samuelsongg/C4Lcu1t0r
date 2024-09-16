class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Calculator _calculator = new Calculator();
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
        while (!endApp)
        {
            // Declare variables and set to empty.
            string numInput1 = "";
            string numInput2 = "";
            string numInput3 = "";
            string numInput4 = "";
            double result = 0;

            // Ask the user to type the first number.
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();
            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();
            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput2 = Console.ReadLine();
            }

            // Ask the user to type the third number.
            Console.Write("Type another number, and then press Enter: ");
            numInput3 = Console.ReadLine();
            double cleanNum3 = 0;
            while (!double.TryParse(numInput3, out cleanNum3))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput3 = Console.ReadLine();
            }

            // Ask the user to type the fourth number.
            Console.Write("Type another number, and then press Enter: ");
            numInput4 = Console.ReadLine();
            double cleanNum4 = 0;
                while (!double.TryParse(numInput4, out cleanNum4))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput4 = Console.ReadLine();
            }

            // Ask the user to choose an operator.
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
            try
            {
                var operationResult = _calculator.DoOperation(cleanNum1, cleanNum2, cleanNum3, cleanNum4, op);

                if (operationResult is double doubleResult)
                {
                    // Handle double result
                    if (double.IsNaN(doubleResult))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", doubleResult);
                    }
                }
                else if (operationResult is string stringResult)
                {
                    // Handle string result
                    Console.WriteLine("Your result: {0}\n", stringResult);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying math.\n - Details: " + e.Message);
            }
            Console.WriteLine("------------------------\n");
            // Wait for the user to respond before closing.
            Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "q") endApp = true;
            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;
    }
}
