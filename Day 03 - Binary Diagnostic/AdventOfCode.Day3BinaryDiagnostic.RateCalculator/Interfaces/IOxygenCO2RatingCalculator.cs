using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{
    public interface IOxygenCO2RatingCalculator
    {
        int CalculateOxygenGeneratorRating();
        int CalculateCO2ScrubberRating();
    }
}
