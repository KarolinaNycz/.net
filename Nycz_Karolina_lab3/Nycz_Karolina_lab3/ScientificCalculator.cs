using System;
using System.Collections.Generic;
using System.Linq;

namespace Kalkulator
{
    public class ScientificCalculator
    {
        private readonly Calculator _calculator;

        public ScientificCalculator()
        {
            _calculator = new Calculator();
        }

        public double Add(double a, double b) => _calculator.Add(a, b);
        public double Subtract(double a, double b) => _calculator.Subtract(a, b);
        public double Multiply(double a, double b) => _calculator.Multiply(a, b);
        public double Divide(double a, double b) => _calculator.Divide(a, b);

        public double Power(double a, double b) => Math.Pow(a, b);

        public double Sqrt(double a)
        {
            if (a < 0)
                throw new ArgumentException("Nie można pierwiastkować liczby ujemnej.");

            return Math.Sqrt(a);
        }

        public double Log(double a)
        {
            if (a <= 0)
                throw new ArgumentException("Logarytm jest określony tylko dla liczb dodatnich.");

            return Math.Log(a);
        }

        public double Sum(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
                throw new ArgumentException("Lista liczb nie może być pusta.");

            return numbers.Sum();
        }

        public double Average(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
                throw new ArgumentException("Lista liczb nie może być pusta.");

            return numbers.Average();
        }

        public double Max(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
                throw new ArgumentException("Lista liczb nie może być pusta.");

            return numbers.Max();
        }

        public double Min(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
                throw new ArgumentException("Lista liczb nie może być pusta.");

            return numbers.Min();
        }
    }
}