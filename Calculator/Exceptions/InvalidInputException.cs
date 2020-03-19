using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class InvalidInputException: Exception
    {
        public InvalidInputException()
        {

        }

        public InvalidInputException(string input)
            : base(String.Format("{0} cannot be added", input))
        {

        }
    }
}
