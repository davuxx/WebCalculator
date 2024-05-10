using Core;
using Core.Enums;
using Core.Models;

namespace Test
{
    public class CalculatorTest
    {
        private Calculator _calc;
        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }
        [TestCase(2, 2, MathOperation.Addition, 4)]
        [TestCase(2, 2, MathOperation.Substraction, 0)]
        [TestCase(2, 2, MathOperation.Multiplication, 4)]
        [TestCase(2, 2, MathOperation.Division, 1)]
        [TestCase(2.123, 2, MathOperation.Addition, 4.123)]
        [TestCase(2.123, 2, MathOperation.Substraction, 0.123)]
        [TestCase(2.123, 2, MathOperation.Multiplication, 4.246)]
        [TestCase(2.123, 2, MathOperation.Division, 1.0615)]
        public void Solve_ValidInput_ReturnsResult(decimal firstNumber, decimal secondNumber, MathOperation operation, decimal expectedResult)
        {
            Assert.AreEqual(expectedResult, _calc.Solve(firstNumber, secondNumber, operation));
        }
        [Test]
        public void Solve_ZeroDivisor_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calc.Solve(1, 0, MathOperation.Division));
        }
        [Test]
        public void Solve_FloorIsTrue_ReturnsWholeNumber()
        {
            Assert.AreEqual(33, _calc.Solve(100, 3, MathOperation.Division, true));
        }

    }
}