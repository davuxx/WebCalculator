using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICalculator
    {
        decimal Solve(decimal firstNumber, decimal secondNumber, MathOperation operation, bool floor = false);
    }
}
