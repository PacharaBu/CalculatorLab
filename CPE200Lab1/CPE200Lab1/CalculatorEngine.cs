using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
     
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (parts.Length >= 4)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isOperator(parts[3]))
                {
                    return PercentCalculate(parts[1], parts[0], parts[2], 4);
                }
            }
            if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else if (isNumber(parts[0]) && OnlyOneOperand(parts[1]))
            {
                return unaryCalculate(parts[1], parts[0], 4);
            }

            else
            {
                return "E";
            }


        }
      
    }
}