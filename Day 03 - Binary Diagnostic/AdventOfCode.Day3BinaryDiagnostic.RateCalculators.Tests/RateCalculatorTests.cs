using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using FluentAssertions;
using System.IO;
using Xunit;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class RateCalculatorTests
    {
        [Fact]
        public void CalculateEpsilon_ReturnsCorrectResult()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new GammaEpsilonRateCalculator(report);
            calculator.CalculateEpsilonRate().Should().Be(9);
        }

        [Fact]
        public void Calculate_ReturnsCorrectResult()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new GammaEpsilonRateCalculator(report);
            calculator.CalculateGammaRate().Should().Be(22);
        }
    }
}
