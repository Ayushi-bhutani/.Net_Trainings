using NUnit.Framework;
using CalculatorApp.Core;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // ================= ADD =================

        [TestCase(2, 3, 5)]
        [TestCase(-2, 3, 1)]
        [TestCase(0, 5, 5)]
        [TestCase(-5, -5, -10)]
        public void Add_ValidInputs_ReturnsCorrectSum(int a, int b, int expected)
        {
            Assert.That(_calculator.Add(a, b), Is.EqualTo(expected));
        }

        // ================= SUBTRACT =================

        [TestCase(10, 5, 5)]
        [TestCase(5, 10, -5)]
        [TestCase(0, 5, -5)]
        [TestCase(-10, -5, -5)]
        public void Subtract_ValidInputs_ReturnsCorrectDifference(int a, int b, int expected)
        {
            Assert.That(_calculator.Subtract(a, b), Is.EqualTo(expected));
        }

        // ================= MULTIPLY =================

        [TestCase(2, 3, 6)]
        [TestCase(-2, 3, -6)]
        [TestCase(0, 100, 0)]
        [TestCase(-5, -5, 25)]
        public void Multiply_ValidInputs_ReturnsCorrectProduct(int a, int b, int expected)
        {
            Assert.That(_calculator.Multiply(a, b), Is.EqualTo(expected));
        }

        // ================= DIVIDE =================

        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-10, 2, -5)]
        [TestCase(0, 5, 0)]
        public void Divide_ValidInputs_ReturnsCorrectQuotient(int a, int b, double expected)
        {
            Assert.That(_calculator.Divide(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.That(
                () => _calculator.Divide(10, 0),
                Throws.TypeOf<DivideByZeroException>()
            );
        }
    }
}
