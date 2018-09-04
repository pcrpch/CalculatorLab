using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> data = new Stack<string>();
            string[] parts = str.Split(' ');
            if(parts.Length == 1)
            {
                return "E";
            }
            for(int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    data.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (data.Count >= 2)
                    {
                        string second = data.Peek();
                        data.Pop();
                        string first = data.Peek();
                        data.Pop();
                        data.Push(calculate(parts[i], first, second, 8));
                    }
                    else
                    {
                        return "E";
                    }
                    
                }
            }
            // your code here
            if(data.Count > 1)
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
