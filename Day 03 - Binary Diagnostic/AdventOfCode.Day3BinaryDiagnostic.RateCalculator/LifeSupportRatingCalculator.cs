using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{
    internal class LifeSupportRatingCalculator
    {
        private readonly IOxygenCO2RatingCalculator ratingCalculator;

        public LifeSupportRatingCalculator(IOxygenCO2RatingCalculator ratingCalculator)
        {
            this.ratingCalculator = ratingCalculator;
        }

        public int Calculate()
        {
            return ratingCalculator.CalculateOxygenGeneratorRating() * ratingCalculator.CalculateCO2ScrubberRating();
        }
    }
}
