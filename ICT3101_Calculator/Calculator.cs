﻿using ICT3101_Calculator;

public class Calculator
{
    private readonly IFileReader _fileReader;

    public Calculator(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }

    public Calculator() { }

    public object DoOperation(double num1, double num2, double num3, double num4, string op)
    {
        object result = double.NaN; // Default value
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
            case "mtbf":
                result = CalculateMTBF(num1, num2);
                break;
            case "availability":
                result = CalculateAvailability(num1, num2);
                break;
            case "failureintensity":
                result = CalculateFailureIntensity(num1, num2, num3);
                break;
            case "expectedfailures":
                result = CalculateExpectedFailures(num1, num2, num3);
                break;
            case "defectdensity":
                result = CalculateDefectDensity(num1, num2);
                break;
            case "musalog":
                result = CalculateMusaLogReliability(num1, num2, num3, num4);
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

    // Calculate MTBF (Mean Time Between Failures)
    public double CalculateMTBF(double mttf, double mttr)
    {
        if (mttf < 0 || mttr < 0)
        {
            throw new ArgumentException("Parameters cannot be negative");
        }

        var result = mttf + mttr;
        if (result < 0)
        {
            result = 0;
            return result;
        }
        else
        {
            return result;
        }
    }

    // Calculate Availability (Availability = MTTF / (MTTF + MTTR))
    public double CalculateAvailability(double mttf, double mttr)
    {
        if (mttf < 0 || mttr < 0)
        {
            throw new ArgumentException("Parameters cannot be negative");
        }

        double mtbf = CalculateMTBF(mttf, mttr);
        double result = mttf / mtbf;

        if (result < 0)
        {
            return 0;
        }
        else
        {
            return result;
        }
    }

    // Calculate the current failure intensity (λ(τ))
    public double CalculateFailureIntensity(double initial_failure_intensity, double avg_failures, double ttl_failures)
    {
        if (initial_failure_intensity < 0 || avg_failures < 0 || ttl_failures < 0)
        {
            throw new ArgumentException("Parameters cannot be negative");
        }

        double result = initial_failure_intensity * (1 - (avg_failures / ttl_failures));

        if (result < 0)
        {
            return 0;
        }
        else
        {
            return result;
        }
    }

    // Calculate the average number of expected failures (μ(τ))
    public double CalculateExpectedFailures(double initial_failure_intensity, double ttl_failures, double time)
    {
        if (initial_failure_intensity < 0 || ttl_failures < 0 || time < 0)
        {
            throw new ArgumentException("Parameters cannot be negative");
        }

        double result = ttl_failures * (1 - Math.Pow(Math.E, (-1 * (initial_failure_intensity / ttl_failures) * time)));

        if (result < 0)
        {
            return 0;
        }
        else
        {
            return result;
        }
    }

    // Defect Density = Number of defects / SSI
    public double CalculateDefectDensity(double defects, double ssi)
    {
        if (ssi < 0 || defects < 0)
        {
            throw new ArgumentException(String.Format("Parameters cannot be negative"));
        }

        if (ssi == 0)
        {
            throw new ArgumentException(String.Format("SSI cannot be zero"));
        }

        return (double)defects / ssi;
    }

    // Calculate the failure intensity of a system using Musa Log
    public double CalculateMusaLogFailureIntensity(double lambda0, double theta, double mu)
    {
        if (lambda0 < 0 || theta < 0 || mu < 0)
        {
            throw new ArgumentException(String.Format("Parameters cannot be negative"));
        }

        double result = lambda0 * (Math.Pow(Math.E, (-1 * theta * mu)));
        return result;
    }

    // Calculate the expected number of failures of a system using Musa Log
    public double CalculateMusaLogExpectedFailures(double lambda0, double theta, double time)
    {
        if (lambda0 < 0 || theta < 0 || time < 0)
        {
            throw new ArgumentException(String.Format("Parameters cannot be negative"));
        }

        double result = (1 / theta) * (Math.Log(lambda0 * theta * time + 1));
        return result;
    }

    // Calculate Musa Log reliability and returns failure intensity and expected failures in a string
    public string CalculateMusaLogReliability(double lambda0, double theta, double mu, double time)
    {
        if (lambda0 < 0 || theta < 0 || mu < 0 || time < 0)
        {
            throw new ArgumentException(String.Format("Parameters cannot be negative"));
        }

        double failureIntensity = CalculateMusaLogFailureIntensity(lambda0, theta, mu);
        double expectedFailures = CalculateMusaLogExpectedFailures(lambda0, theta, time);

        return $"Failure Intensity: {failureIntensity}, Expected Failures: {expectedFailures}";
    }

    public double GenMagicNum(double input, IFileReader fileReader)
    {
        double result = 0;
        int choice = Convert.ToInt16(input);

        string[] magicStrings = fileReader.Read("MagicNumbers.txt");
        
        if ((choice >= 0) && (choice < magicStrings.Length))
        {
            result = Convert.ToDouble(magicStrings[choice]);
        }
        
        result = (result > 0) ? (2 * result) : (-2 * result);
        return result;
    }
}

public class FileReader : IFileReader
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}