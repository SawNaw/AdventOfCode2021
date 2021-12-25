using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators
{ 
    internal class PowerConsumptionCalculator
    {
        private readonly IRateCalculator rateCalculator;

        public PowerConsumptionCalculator(IRateCalculator rateCalculator)
        {
            this.rateCalculator = rateCalculator;   
        }

        public int Calculate()
        {
            return rateCalculator.CalculateGammaRate() * rateCalculator.CalculateEpsilonRate();
        }
    }
}
