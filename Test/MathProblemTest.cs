using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MathProblemTest
    {
        [TestCase("1 + 1 + 1")]
        [TestCase("")]
        [TestCase(" + 1452 + 555")]
        [TestCase("1 + 2..2")]
        [TestCase("1 x 1")]
        [TestCase("1+1")]
        [TestCase("1 +  + 1")]
        public void Parse_InvalidFormat_ThrowsArgumentException(string s)
        {
            Assert.Throws<ArgumentException>(() => MathProblem.Parse(s));
        }
        [TestCase("2 + 2", 2, 2, MathOperation.Addition)]
        [TestCase("2 - 2", 2, 2, MathOperation.Substraction)]
        [TestCase("2 * 2", 2, 2, MathOperation.Multiplication)]
        [TestCase("2 / 2", 2, 2, MathOperation.Division)]
        [TestCase("2,123 + 2", 2.123, 2, MathOperation.Addition)]
        [TestCase("2,123 - 2", 2.123, 2, MathOperation.Substraction)]
        [TestCase("2,123 * 2", 2.123, 2, MathOperation.Multiplication)]
        [TestCase("2,123 / 2", 2.123, 2, MathOperation.Division)]
        [TestCase("2 + 2,123", 2, 2.123, MathOperation.Addition)]
        [TestCase("2 - 2,123", 2, 2.123, MathOperation.Substraction)]
        [TestCase("2 * 2,123", 2, 2.123, MathOperation.Multiplication)]
        [TestCase("2 / 2,123", 2, 2.123, MathOperation.Division)]
        public void Parse_ValidFormat_ReturnsMathProblem(string s, decimal firstNumber, decimal secondNumber, MathOperation operation)
        {
            MathProblem mathProblem = MathProblem.Parse(s);
            Assert.True(mathProblem.FirstNumber == firstNumber && mathProblem.SecondNumber == secondNumber && mathProblem.Operation == operation);
        }
        
    }
}
