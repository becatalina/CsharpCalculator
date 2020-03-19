using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Utils
    {
        public double sqrt(double a) {
            return Math.Sqrt(a);
        }
        public double add(double a, double b)
        {
            return (a + b);
        }

        public double subtract(double a, double b)
        {
            return (a - b);
        }

        public double multiply(double a, double b)
        {
            return (a * b);
        }

        public double divide(double a, double b)
        {
            return (a / b);
        }

        

        
    }
}
