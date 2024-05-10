using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MathProblem : EntityBase
    {
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public MathOperation Operation { get; set; }
        public decimal? Result { get; set; }
        private static Dictionary<string, MathOperation> operationsMap = new Dictionary<string, MathOperation>()
        {
            ["+"] = MathOperation.Addition,
            ["-"] = MathOperation.Substraction,
            ["*"] = MathOperation.Multiplication,
            ["/"] = MathOperation.Division,
        };
        public static MathProblem Parse(string s)
        {
            string[] components = s.Replace('.', ',').Split(' ');
            if (components.Length != 3)
            {
                throw new ArgumentException("Invalid number of arguments.");
            }
            decimal firstNumber, secondNumber;
            if (!decimal.TryParse(components[0], out firstNumber) || !decimal.TryParse(components[2], out secondNumber))
            {
                throw new ArgumentException("Either first or second number is invalid.");
            }
            MathOperation operation;
            if (!operationsMap.TryGetValue(components[1], out operation))
            {
                throw new ArgumentException("Invalid math operator");
            }
            MathProblem mathProblem = new MathProblem();
            mathProblem.FirstNumber = firstNumber;
            mathProblem.SecondNumber = secondNumber;
            mathProblem.Operation = operation;
            return mathProblem;
        }
        public override string ToString()
        {
            return $"{FirstNumber} {operationsMap.FirstOrDefault(x => x.Value == Operation).Key} {SecondNumber} = {Result}";
        }
    }
    
}
