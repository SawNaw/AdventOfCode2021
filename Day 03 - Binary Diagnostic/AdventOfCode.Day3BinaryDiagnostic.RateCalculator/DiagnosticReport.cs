using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{
    internal class DiagnosticReport
    {
        public IReadOnlyList<BinaryNumber>? Content {get; init;}

        public DiagnosticReport(string inputFilePath)
        {
            List<BinaryNumber> fileContent = new();
            var lines = File.ReadLines(inputFilePath);
            foreach (var line in lines)
            {
                fileContent.Add(new BinaryNumber(line));
            }

            if (AllLinesHaveSameLengthAsFirstLine(fileContent))
            {
                Content = fileContent;
            }
        }

        private bool AllLinesHaveSameLengthAsFirstLine(List<BinaryNumber> fileContent)
        {
            int lengthOfFirstLine = fileContent.First().Length;

            foreach (var line in fileContent)
            {
                if (line.Length != lengthOfFirstLine)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
