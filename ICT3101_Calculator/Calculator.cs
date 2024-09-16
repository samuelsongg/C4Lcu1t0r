public class Calculator
{
    public Calculator() { }
    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value
                                    // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = Add(num1, num2);
                break;
            case "s":
                result = Subtract(num1, num2);
                break;
            case "m":
                result = Multiply(num1, num2);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                result = Divide(num1, num2);
                break;
            case "f":
                result = Factorial(num1);
                break;
            case "t":
                result = Triangle(num1, num2);
                break;
            case "c":
                result = Circle(num1);
                break;
            case "1":
                result = Qn17a(num1, num2);
                break;
            case "2":
                result = Qn17b(num1, num2);
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
    public double Add(double num1, double num2)
    {
        return (num1 + num2);
    }
    public double Subtract(double num1, double num2)
    {
        return (num1 - num2);
    }
    public double Multiply(double num1, double num2)
    {
        return (num1 * num2);
    }
    public double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            if (num1 == 0)
            {
                return 1;
            }

            return double.PositiveInfinity;
        }
        else
        {
            return num1 / num2;
        }
    }
    public double Factorial(double num1)
    {
        double result = 1;

        if (num1 < 0 || num1 % 1 != 0)
        {
            throw new ArgumentException(String.Format("Error doing factorial."));
        }
        else if (num1 == 0)
        {
            return 1;
        }
        else
        {
            for (double i = num1; i > 0; i--)
            {
                result = result * i;
            }

            return result;
        }
    }

    public double Triangle(double length, double height)
    {
        if (length <= 0 || height <= 0)
        {
            throw new ArgumentException(String.Format("Error calculating area of Triangle."));
        }
        else
        {
            double area = (1 / 2) * length * height;
            return area;
        }
    }

    public double Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException(String.Format("Error calculating area of Circle."));
        }
        else
        {
            double area = 3.14 * radius * radius;
            return area;
        }
    }

    // Qn17 a)
    public double Qn17a(double a, double b)
    {
        if ((a / b) > (a - b))
        {
            return Factorial(a);
        }
        else if ((a / b) < (a - b))
        {
            return (Factorial(a) / 2);
        }
        else
        {
            throw new ArgumentException(String.Format("Error encountered."));
        }
    }

    // Qn17 b)
    public double Qn17b(double a, double b)
    {
        if (a == b)
        {
            return (Factorial(a) / Factorial(b));
        }
        else if (a > b)
        {
            return ((Factorial(a) / Factorial(b)) / (a - b));
        }
        else
        {
            throw new ArgumentException(String.Format("Error encountered."));
        }
    }
}
