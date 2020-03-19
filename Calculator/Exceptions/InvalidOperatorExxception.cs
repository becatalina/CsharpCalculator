using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class InvalidOperatorExxception: Exception
    {
        public InvalidOperatorExxception()
        {

        }
        public InvalidOperatorExxception(string input)
            : base(String.Format("Invalid Operator Typed: {0}", input))
        {
            
        }
    }
}
