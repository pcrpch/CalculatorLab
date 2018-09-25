using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {

        public string calculate(string str)
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
                    data.Push(calculate(parts[i], first));
                }
                else if (isOperator(parts[i]))
                {
                    if (data.Count >= 2)
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
                    else
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
