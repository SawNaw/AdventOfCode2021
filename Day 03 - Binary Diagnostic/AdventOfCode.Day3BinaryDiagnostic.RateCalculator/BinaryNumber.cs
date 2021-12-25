using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{
    internal record class BinaryNumber
    {
        public int Length => this.RawContent.Length;
        private string RawContent { get; init; }
        private readonly BitArray contentAsBitArray;

        public BinaryNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input), "A row cannot be initialized with null or empty string. ");
            }

            this.RawContent = input;

            this.contentAsBitArray = new BitArray(input.Select(i => BitToBool(i))
                                                  .ToArray());
        }

        public bool DigitAt(int index)
        {
            return contentAsBitArray[index];
        }

        private static bool BitToBool(char bit)
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
