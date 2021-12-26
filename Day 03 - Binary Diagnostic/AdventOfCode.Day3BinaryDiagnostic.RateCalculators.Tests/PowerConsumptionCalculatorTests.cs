using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xunit;
using FluentAssertions;
using Moq;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class PowerConsumptionCalculatorTests
    {
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(4, 5, 20)]
        [InlineData(6, 7, 42)]
        public void Calculate_ReturnsProduct_OfGammaAndEpsilonRates(int gammaRate, int epsilonRate, int expectedPowerConsumption)
        {
            var rateCalculator = new Mock<IGammaEpsilonRateCalculator>();
            rateCalculator.Setup(r => r.CalculateGammaRate()).Returns(gammaRate);
            rateCalculator.Setup(r => r.CalculateEpsilonRate()).Returns(epsilonRate);

            var powerConsumptionCalculator = new PowerConsumptionCalculator(rateCalculator.Object);
            powerConsumptionCalculator.Calculate().Should().Be(expectedPowerConsumption);
        }

        [Fact]
        public void Calculate_ReturnsCorrectResult_ForInputFile()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new PowerConsumptionCalculator(new GammaEpsilonRateCalculator(report));
            calculator.Calculate().Should().Be(198);
        }

        [Fact]
        public void Calculate_ReturnsCorrectResult_ForMyPersonalInputFile()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\MyPersonalInputFile.txt");
            var calculator = new PowerConsumptionCalculator(new GammaEpsilonRateCalculator(report));
            calculator.Calculate().Should().Be(3320834);
        }
    }
}
