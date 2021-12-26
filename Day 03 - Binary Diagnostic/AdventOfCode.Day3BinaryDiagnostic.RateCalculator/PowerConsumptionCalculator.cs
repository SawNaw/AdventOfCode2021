using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{ 
    internal class PowerConsumptionCalculator
    {
        private readonly IGammaEpsilonRateCalculator rateCalculator;

        public PowerConsumptionCalculator(IGammaEpsilonRateCalculator rateCalculator)
        {
            this.rateCalculator = rateCalculator;   
        }

        public int Calculate()
        {
            return rateCalculator.CalculateGammaRate() * rateCalculator.CalculateEpsilonRate();
        }
    }
}
