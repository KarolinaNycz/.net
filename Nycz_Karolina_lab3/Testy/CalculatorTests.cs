using NUnit.Framework;
using Kalkulator;
using System;

namespace Testy
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Add(2, 3), Is.EqualTo(5));
        }

        [Test]
        public void Subtract_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Subtract(5, 3), Is.EqualTo(2));
        }

        [Test]
        public void Multiply_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Multiply(4, 3), Is.EqualTo(12));
        }

        [Test]
        public void Divide_ShouldReturnCorrectResult()
        {
            Assert.That(calculator.Divide(10, 2), Is.EqualTo(5));
        }

        [Test]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}