using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        /// <summary>
        ///  Check if input is a number
        /// </summary>
        /// <param name="str">Input is string that split from the display</param>
        /// <returns>False if input is not a number otherwise True</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        /// <summary>
        /// Check if input is a operator
        /// </summary>
        /// <param name="str">Input is string that split from the display</param>
        /// <returns>False if input is not a operator otherwise True</returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">Input is string that split from the display</param>
        /// <returns>False if input is not a operator for one number otherwise True</returns>
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
        /// <summary>
        /// Split string from display to calculate
        /// </summary>
        /// <param name="str">string from display</param>
        /// <returns>result of calculator</returns>
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
        /// <summary>
        /// Calculate one number with unaryoperator
        /// </summary>
        /// <param name="operate">Unaryoperator</param>
        /// <param name="operand">Number</param>
        /// <param name="maxOutputSize">Size of result</param>
        /// <returns>result of calculate</returns>
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
        /// <summary>
        /// Calculate two numbers with binary operator
        /// </summary>
        /// <param name="operate">operator</param>
        /// <param name="firstOperand">First number</param>
        /// <param name="secondOperand">Second Number</param>
        /// <param name="maxOutputSize">Size of result</param>
        /// <returns>result of calculate</returns>
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
