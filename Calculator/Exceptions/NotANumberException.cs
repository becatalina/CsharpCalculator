using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class NotANumberException: Exception
    {
        public NotANumberException()
        {

        }

        public NotANumberException(string input)
            :base(String.Format("A number must follow after an operand"))
        {

        }
    }
}
