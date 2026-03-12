using NUnit.Framework;
using Kalkulator;
using System;
using System.Collections.Generic;

namespace Testy
{
    [TestFixture]
    public class ScientificCalculatorTests
    {
        private ScientificCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new ScientificCalculator();
        }

        [Test]
        public void Power_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Power(2, 3), Is.EqualTo(8));
        }

        [Test]
        public void Sqrt_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Sqrt(9), Is.EqualTo(3));
        }

        [Test]
        public void Sqrt_Negative_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => calculator.Sqrt(-1));
        }

        [Test]
        public void Log_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Log(Math.E), Is.EqualTo(1).Within(0.0001));
        }

        [Test]
        public void Log_NonPositive_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => calculator.Log(0));
        }

        [Test]
        public void Sum_ShouldReturnCorrectResult()
        {
            var numbers = new List<double> { 1, 2, 3, 4 };
            Assert.That(calculator.Sum(numbers), Is.EqualTo(10));
        }

        [Test]
        public void Average_ShouldReturnCorrectResult()
        {
            var numbers = new List<double> { 2, 4, 6, 8 };
            Assert.That(calculator.Average(numbers), Is.EqualTo(5));
        }

        [Test]
        public void Max_ShouldReturnCorrectResult()
        {
            var numbers = new List<double> { 1, 9, 3 };
            Assert.That(calculator.Max(numbers), Is.EqualTo(9));
        }

        [Test]
        public void Min_ShouldReturnCorrectResult()
        {
            var numbers = new List<double> { 1, 9, -3 };
            Assert.That(calculator.Min(numbers), Is.EqualTo(-3));
        }
    }
}