﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public  class TheCalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":   //add case %
                    return true;
            }
            return false;
        }

        public bool OnlyOneOperand(string str)  //function use for only one operate ex. 1/2 sqrt(4)
        {
            if (str == "1/x" || str == "√")
            {
                return true;
            }
            else return false;

        }
        // already deleted process
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        public string PercentCalculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)    // return case of secondoperand
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "÷":
                    return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
            }
            return "E";
        }
        public string PercentResult(string firstOperand, string secondOperand, int maxOutputSize = 8)     // return result
        {

            return (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand))).ToString();
        }
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);//result.ToString("N" + remainLength)
                    }
                    break;
                case "%":
                    //your code here
                    //line 105 - 124

                    break;
            }
            return "E";
        }
    }
}
