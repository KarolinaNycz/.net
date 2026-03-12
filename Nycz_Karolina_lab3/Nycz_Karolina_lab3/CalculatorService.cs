using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Kalkulator
{
    public class CalculatorService
    {
        private readonly ScientificCalculator _calculator;

        public CalculatorService()
        {
            _calculator = new ScientificCalculator();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Kalkulator naukowy w C#");
                Console.WriteLine("Wybierz operację: +, -, *, /, ^, sqrt, log, sum, avg, max, min");
                Console.WriteLine("Aby zakończyć wpisz: exit");
                Console.Write("> ");

                string? operation = Console.ReadLine()?.Trim().ToLower();

                if (operation == "exit")
                {
                    Console.WriteLine("Zamykanie kalkulatora...");
                    break;
                }

                try
                {
                    switch (operation)
                    {
                        case "+":
                            ExecuteBinaryOperation(_calculator.Add);
                            break;
                        case "-":
                            ExecuteBinaryOperation(_calculator.Subtract);
                            break;
                        case "*":
                            ExecuteBinaryOperation(_calculator.Multiply);
                            break;
                        case "/":
                            ExecuteBinaryOperation(_calculator.Divide);
                            break;
                        case "^":
                            ExecuteBinaryOperation(_calculator.Power);
                            break;
                        case "sqrt":
                            ExecuteUnaryOperation(_calculator.Sqrt);
                            break;
                        case "log":
                            ExecuteUnaryOperation(_calculator.Log);
                            break;
                        case "sum":
                            ExecuteCollectionOperation(_calculator.Sum, "sumowania");
                            break;
                        case "avg":
                            ExecuteCollectionOperation(_calculator.Average, "obliczenia średniej");
                            break;
                        case "max":
                            ExecuteCollectionOperation(_calculator.Max, "znalezienia maksimum");
                            break;
                        case "min":
                            ExecuteCollectionOperation(_calculator.Min, "znalezienia minimum");
                            break;
                        default:
                            Console.WriteLine("Błąd: Nieznana operacja.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd: {ex.Message}");
                }
            }
        }

        private void ExecuteBinaryOperation(Func<double, double, double> operation)
        {
            double a = ReadDouble("Podaj pierwszą liczbę:");
            double b = ReadDouble("Podaj drugą liczbę:");

            double result = operation(a, b);
            Console.WriteLine($"Wynik: {result}");
        }

        private void ExecuteUnaryOperation(Func<double, double> operation)
        {
            double a = ReadDouble("Podaj liczbę:");

            double result = operation(a);
            Console.WriteLine($"Wynik: {result}");
        }

        private void ExecuteCollectionOperation(Func<IEnumerable<double>, double> operation, string description)
        {
            Console.WriteLine($"Podaj liczby do {description}, oddzielone spacją:");
            Console.Write("> ");
            string? input = Console.ReadLine();

            List<double> numbers = ParseNumbers(input);
            double result = operation(numbers);

            Console.WriteLine($"Wynik: {result}");
        }

        private double ReadDouble(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");

            string? input = Console.ReadLine();

            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                throw new FormatException("Podano nieprawidłową liczbę.");

            return result;
        }

        private List<double> ParseNumbers(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Nie podano żadnych liczb.");

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<double> numbers = new List<double>();

            foreach (string part in parts)
            {
                if (!double.TryParse(part, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    throw new FormatException($"Nieprawidłowa wartość: {part}");

                numbers.Add(value);
            }

            return numbers;
        }
    }
}