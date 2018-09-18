﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;
        }

        public bool isUnaryOperator(string str)
        {
            switch (str)
            {
                case "1/x":
                case "√":
                    return true;
            }
            return false;
        }
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            try
            {
                return calculate(parts[1], parts[0], parts[2], 4);
                
            }
            catch
            {
                return "E";
            }
        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        if (Convert.ToDouble(operand) < 0)
                        {
                            return "E";
                        }
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
                        double answer = Convert.ToDouble(result.ToString("N" + remainLength));
                        return answer.ToString();
                    }
                case "1/x":
                    if(operand != "0")
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
                        double answer = Convert.ToDouble(result.ToString("N" + remainLength));
                        return answer.ToString();
                    }
                    break;
            }
            return "E";
        }
        
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8, string operatorPercent = null)
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
                        double answer = Convert.ToDouble(result.ToString("N" + remainLength));
                        return answer.ToString();
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) * 0.01).ToString();
                case "M+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "M-":
                    return (Convert.ToDouble(secondOperand) - Convert.ToDouble(firstOperand)).ToString();
                case "MC":
                    return "0";
                case "MS":
                    return firstOperand;
            }
            return "E";
        }
    }
}
