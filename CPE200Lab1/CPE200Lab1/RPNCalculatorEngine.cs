﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        /// <summary>
        /// Split string from display to calculate and put into stack
        /// </summary>
        /// <param name="str">string from display</param>
        /// <returns>result of calculator</returns>
        public string Process(string str)
        {
            Stack<string> data = new Stack<string>();
            string[] parts = str.Split(' ');
            string second = string.Empty;
            string first = string.Empty;
            string[] temp = { string.Empty, string.Empty, string.Empty };
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    data.Push(parts[i]);
                }
                else if (isUnaryOperator(parts[i]))
                {
                    first = data.Peek();
                    data.Pop();
                    data.Push(unaryCalculate(parts[i], first));
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        second = data.Peek();
                        data.Pop();
                        first = data.Peek();
                        if (parts[i] != "%")
                        {
                            data.Pop();
                        }
                        data.Push(calculate(parts[i], first, second));
                    }
                    catch
                    {
                        return "E";
                    }
                }
            }
            // your code here
            if (data.Count > 1)
            {
                return "E";
            }
            else
            {
                return data.Peek();
            }
        }
    }
}
