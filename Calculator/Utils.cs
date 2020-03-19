using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public static class Utils
    {
        public static void AddComma(ref String input, bool isRO) {
            Regex numeric = new Regex(@"\b\w+[0-9]\b");

            if (!isRO) {
                input = input.Replace(",", "");

                foreach (Match match in numeric.Matches(input)) {
                    input = input.Replace(match.ToString(), Format(match.ToString(), isRO));
                }
                return;
            }

            input = input.Replace(".", "");
            foreach (Match match in numeric.Matches(input))
            {
                input = input.Replace(match.ToString(), Format(match.ToString(), isRO));
            }
            return;
        }

        private  static String Format(String number, bool isRo) {
            if (isRo) {
                return Convert.ToDecimal(number)
                    .ToString("N0", CultureInfo.CreateSpecificCulture("de-DE"));
            }
            return String.Format("{0:n0}", Convert.ToDecimal(number));
        }

        public static void SwitchLang(ref String input) {

            var res = input.Select(x => x == '.' ? ',' : (x == ',' ? '.' : x)).ToArray();
            input = new string(res);

        }

        public static object Solve(string equation)
        {
            DataTable dt = new DataTable();
            var result = dt.Compute(equation, "");
            return result;
        }
    }
}
