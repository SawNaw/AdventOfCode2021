using AdventOfCode.Day3BinaryDiagnostic.DataStructures;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{
    public class RatingCalculator
    {
        private DiagnosticReport diagnosticReport;
        public RatingCalculator(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
        }

        public int CalculateOxygenGeneratorRating()
        {
            return CalculateRating(RatingType.OxygenGeneratorRating);
        }

        public int CalculateCO2ScrubberRating()
        {
            return CalculateRating(RatingType.CO2ScrubberRating);
        }

        private int CalculateRating(RatingType ratingType)
        {
            var numbers = new List<BinaryNumber>(diagnosticReport.Content);

            for (int i = 0; i < diagnosticReport.NumberOfBitsPerRow; i++)
            {
                var digitsInCurrentBitPosition = GetAllDigitsInBitPosition(i, numbers);

                if (ratingType == RatingType.OxygenGeneratorRating)
                {
                    char mostCommon = GetMostCommonDigitOrOneIfEquallyCommon(digitsInCurrentBitPosition);
                    numbers.RemoveAll(n => n.ContentAsString[i] != mostCommon);
                }
                else if (ratingType == RatingType.CO2ScrubberRating)
                {
                    char leastCommon = GetLeastCommonDigitOrZeroIfEquallyCommon(digitsInCurrentBitPosition);
                    numbers.RemoveAll(n => n.ContentAsString[i] != leastCommon);
                }
                else
                {
                    throw new ArgumentException("Invalid rating type passed here.", nameof(ratingType));
                }

                if (numbers.Count == 1)
                {
                    Console.WriteLine("Returing");
                    return BinaryToDecimal(numbers.Single().ContentAsString);
                }
            }

            throw new Exception("Rating calculation failed.");
        }

        private List<char> GetAllDigitsInBitPosition(int index, List<BinaryNumber> numbers)
        {
            var digitsInColumn = new List<char>();

            foreach (var item in numbers)
            {
                digitsInColumn.Add(item.ContentAsString[index]);
            }

            return digitsInColumn;
        }

        // Returns the most common digit in a list of 0's and 1's, or 1 if the list contains equal counts of both.
        private static char GetMostCommonDigitOrOneIfEquallyCommon(List<char> digits)
        {
            ThrowIfContainsNonBinaryCharacters(digits);

            return digits.Count(x => x == '0') > digits.Count(x => x == '1') ? '0' : '1';
        }

        // Returns the least common digit in a list of 0's and 1's, or 0 if the list contains equal counts of both.
        private static char GetLeastCommonDigitOrZeroIfEquallyCommon(List<char> digits)
        {
            ThrowIfContainsNonBinaryCharacters(digits);

            return digits.Count(x => x == '0') > digits.Count(x => x == '1') ? '1' : '0';
        }

        private int BinaryToDecimal(string binaryNumber)
        {
            if (binaryNumber.Any(x => x != '0' && x != '1'))
            {
                throw new ArgumentException("Invalid binary number supplied.", nameof(binaryNumber));
            }

            return Convert.ToInt32(binaryNumber, 2);
        }

        private static void ThrowIfContainsNonBinaryCharacters(List<char> digits)
        {
            if (digits.Any(d => d != '0' && d != '1'))
            {
                throw new ArgumentException("This list may only contain 0's or 1's.", nameof(digits));
            }
        }

        private enum RatingType
        {
            OxygenGeneratorRating,
            CO2ScrubberRating,
        }
    }
}
