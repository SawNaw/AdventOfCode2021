using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{
    internal class RateCalculator : IRateCalculator
    {
        private DiagnosticReport diagnosticReport;
        public RateCalculator(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
        }

        public int CalculateGammaRate()
        {
            return CalculateRate(RateType.Gamma);
        }

        public int CalculateEpsilonRate()
        {
            return CalculateRate(RateType.Epsilon);
        }

        private int CalculateRate(RateType rateType)
        {
            char[] result = new char[diagnosticReport.NumberOfBitsPerRow];

            for (int i = 0; i < diagnosticReport.NumberOfBitsPerRow; i++)
            {
                var digitsInColumn = new List<char>();
                foreach (var row in diagnosticReport.Content)
                {
                    digitsInColumn.Add(row.ContentAsString[i]);
                    if (rateType == RateType.Gamma)
                    {
                        result[i] = digitsInColumn.Count(x => x == '0') > digitsInColumn.Count(x => x == '1') ? '0' : '1';
                    }
                    else if (rateType == RateType.Epsilon)
                    {
                        result[i] = digitsInColumn.Count(x => x == '0') < digitsInColumn.Count(x => x == '1') ? '0' : '1';
                    }
                    else 
                    {
                        throw new ArgumentException("Invalid rate type passed here.", nameof(rateType));
                    }
                }
            }

            return BinaryToDecimal(new string(result));
        }

        private int BinaryToDecimal(string binaryNumber)
        {
            if (binaryNumber.Any(x => x != '0' && x != '1'))
            {
                throw new ArgumentException("Invalid binary number supplied.", nameof(binaryNumber));
            }

            return Convert.ToInt32(binaryNumber, 2);
        }
        private enum RateType
        {
            Gamma,
            Epsilon,
        }
    }
}
