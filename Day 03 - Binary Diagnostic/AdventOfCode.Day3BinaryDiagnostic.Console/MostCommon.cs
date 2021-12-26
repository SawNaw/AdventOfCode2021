using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.Console
{
    public static class MostCommon
    {
        public static char GetMostCommon(char[] digits)
        {
           return digits.Count(x => x == '0') > digits.Count(x => x == '1') ? '0' : '1';
        }

        public static char GetLeastCommon(char[] digits)
        {
            return digits.Count(x => x == '0') > digits.Count(x => x == '1') ? '1' : '0';
        }
    }
}
