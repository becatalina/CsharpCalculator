using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calc
    {
        public double Solve(string equation)
        {
            equation = Regex.Replace(equation, @"\s+", "");
            Operation operation = new Operation();
            operation.Parse(equation);
            double result = operation.Solve();
            return result;
        }
    }
}
