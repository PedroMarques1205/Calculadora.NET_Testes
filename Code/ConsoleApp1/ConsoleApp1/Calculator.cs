using System;

public class Calculator
{
    static double Add(double num1, double num2)
    {
        return num1 + num2;
    }

    static double Subtract(double num1, double num2)
    {
        return num1 - num2;
    }

    static double Multiply(double num1, double num2)
    {
        return num1 * num2;
    }

    static double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero!");
        }
        return num1 / num2;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== C# .NET Calculator ===");
        Console.WriteLine("4 Methods: Add, Subtract, Multiply, Divide\n");

        while (true)
        {
            try
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice (1-5): ");

                string? choice = Console.ReadLine();

                if (choice == "5")
                {
                    Console.WriteLine("\nThank you for using the calculator. Goodbye!");
                    break;
                }

                if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                {
                    Console.WriteLine("Invalid choice! Please select 1-5.");
                    continue;
                }

                Console.Write("Enter first number: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue;
                }

                Console.Write("Enter second number: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue;
                }

                double result = 0;
                string operation = "";

                switch (choice)
                {
                    case "1":
                        result = Add(num1, num2);
                        operation = "+";
                        break;
                    case "2":
                        result = Subtract(num1, num2);
                        operation = "-";
                        break;
                    case "3":
                        result = Multiply(num1, num2);
                        operation = "*";
                        break;
                    case "4":
                        result = Divide(num1, num2);
                        operation = "/";
                        break;
                }

                Console.WriteLine($"\nResult: {num1} {operation} {num2} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }
    }
}