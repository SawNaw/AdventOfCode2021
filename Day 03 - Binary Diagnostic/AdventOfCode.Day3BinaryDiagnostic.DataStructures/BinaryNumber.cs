using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.DataStructures
{
    public class BinaryNumber
    {
        public int Length => this.ContentAsString.Length;
        public string ContentAsString { get; init; }
        private readonly bool[] contentAsBoolArray;

        public BinaryNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input), "A row cannot be initialized with null or empty string. ");
            }

            this.ContentAsString = input;

            this.contentAsBoolArray = input.Select(i => CharToBool(i))
                                           .ToArray();
        }

        public bool DigitAt(int index)
        {
            return contentAsBoolArray[index];
        }

        private static bool CharToBool(char bit)
        {
            if (bit == '0')
            {
                return false;
            }
            else if (bit == '1')
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Found bit {bit}. All bits read must be 0 or 1.");
            }
        }
    }
}
