using Core.Enums;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Calculator : ICalculator
    {
        private ILogger _logger;
        public Calculator(ILogger logger = null)
        {
            _logger = logger;
            
        }
        
        public decimal Solve(decimal firstNumber, decimal secondNumber, MathOperation operation, bool floor = false)
        {
            try
            {
                decimal result;
                switch (operation)
                {
                    case MathOperation.Addition:
                        result = firstNumber + secondNumber;
                        break;
                    case MathOperation.Substraction:
                        result = firstNumber - secondNumber;
                        break;
                    case MathOperation.Multiplication:
                        result = firstNumber * secondNumber;
                        break;
                    case MathOperation.Division:
                        result = firstNumber / secondNumber;
                        break;
                    default:
                        result = 0;
                        break;
                }
                if (floor)
                    return Math.Floor(result);
                else
                    return result;
            } 
            catch (Exception e)
            {
                SendError(e);
                throw;
            }
            
        }
        private void SendError(Exception exception)
        {
            if (_logger == null)
                return;
            _logger.Log(exception);
        }
    }
}
