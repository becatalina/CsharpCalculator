using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class InvalidParanthesisException: Exception
    {
        public InvalidParanthesisException()
        {

        }

        public InvalidParanthesisException(string input)
            :base(String.Format("Invalid number of paranthesis"))
        {

        }
    }
}
